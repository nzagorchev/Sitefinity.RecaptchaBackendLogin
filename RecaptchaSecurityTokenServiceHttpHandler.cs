using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Security.Claims;
using Telerik.Sitefinity.Services;

namespace RecaptchaBackendLogin
{
    public class RecaptchaSecurityTokenServiceHttpHandler : SecurityTokenServiceHttpHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            var requestContext = context.Request.RequestContext;
            var vals = requestContext.RouteData.Values;
            var service = ((string)vals["Service"]).ToLower();
            bool isFormRequest = context.Request.Params["isFormRequest"] != null;

            string requestMethod = context.Request.HttpMethod.ToUpperInvariant();
            // auth request
            if (requestMethod == "POST")
            {
                // if not signout request
                if (!(service == "signout" || "true".Equals(context.Request.QueryString["sign_out"], StringComparison.OrdinalIgnoreCase)))
                {
                    // g-recaptcha-response: POST parameter when the user submits the form with the recaptcha on the site
                    string recaptchaValue = context.Request.Params["g-recaptcha-response"];
                    var test = context.Request.Params["nokey"];
                    if (!string.IsNullOrEmpty(recaptchaValue))
                    {
                        bool isValid = this.ValidateCaptcha(recaptchaValue);
                        if (!isValid)
                        {
                            string message = Res.Get<RecaptchaResources>().NotValidCaptchaErrorMessage;
                            this.SendLoginForm(context, message);
                            return;
                        }
                    }
                    else
                    {
                        string message = Res.Get<RecaptchaResources>().NoCaptchaResponseErrorMessage;
                        this.SendLoginForm(context, message);
                        return;
                    }
                }
            }

            base.ProcessRequest(context);
        }

        /// <summary>
        /// Validates recaptcha value using the recaptcha API
        /// </summary>
        /// <param name="recaptchaValue">the recaptcha value to validate</param>
        /// <returns>returns if the captcha valid or not</returns>
        protected virtual bool ValidateCaptcha(string recaptchaValue)
        {
            // API Request             
            // URL: https://www.google.com/recaptcha/api/siteverify
            // METHOD: POST          
            // POST        Parameter Description
            // secret	    Required. The shared key between your site and ReCAPTCHA.
            // response	Required. The user response token provided by the reCAPTCHA to the user and provided to your site on.
            // remoteip	Optional. The user's IP address.

            string secretKey = Config.Get<RecaptchaConfig>().RecaptchaSecretKey;
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new ArgumentNullException("secretKey", "Recaptcha secret key is not set!");
            }

            using (var client = new HttpClient())
            {
                var data = new Dictionary<string, string>
                {
                    { "secret", secretKey },
                    { "response", recaptchaValue }
                };

                var content = new FormUrlEncodedContent(data);
                // use not async request - get the result
                var response = client.PostAsync(RecaptchaSecurityTokenServiceHttpHandler.RecaptchaResponseUrl, content).Result;
                // read not async - get the result
                string responseString = response.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrEmpty(responseString))
                {
                     RecaptchaResponse recaptchaResponse = JsonConvert.DeserializeObject<RecaptchaResponse>(responseString);

                     if (recaptchaResponse.Success)
                     {
                         return true;
                     }
                     else if (recaptchaResponse.ErrorCodes != null && recaptchaResponse.ErrorCodes.Length > 0)
                     {
                         foreach (var errorCode in recaptchaResponse.ErrorCodes)
                         {
                             if (errorCode == RecaptchaSecurityTokenServiceHttpHandler.RecaptchaResponseInvalidInputSecret)
                             {
                                 throw new ArgumentException("recaptchaSecret", "The secret parameter is invalid or malformed.");
                             }
                         }
                     }
                }
            }

            return false;
        }

        public static void Register()
        {
            var routesCollection = System.Web.Routing.RouteTable.Routes;
            var path = Telerik.Sitefinity.Security.Claims.Constants.LocalService + "/{*Service}";
            var route = routesCollection
                .Where(r => r.GetType() == typeof(System.Web.Routing.Route)
                    && (r as System.Web.Routing.Route).Url == path)
                    .FirstOrDefault();

            if (route != null)
            {
                var index = routesCollection.IndexOf(route);
                if (index > -1)
                {
                    var currentRoute = routesCollection[index] as System.Web.Routing.Route;
                    var routeNew = new RouteHandler<RecaptchaSecurityTokenServiceHttpHandler>();
                    currentRoute.RouteHandler = routeNew;
                }
            }
        }

        internal static readonly string RecaptchaResponseUrl = "https://www.google.com/recaptcha/api/siteverify";
        internal static readonly string RecaptchaResponseInvalidInputSecret = "invalid-input-secret";
    }
}
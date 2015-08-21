using Telerik.Sitefinity.Localization;

namespace RecaptchaBackendLogin
{
    [ObjectInfo(typeof(RecaptchaResources), Title = "RecaptchaResourcesTitle", Description = "RecaptchaResourcesDescription")]
    public class RecaptchaResources : Resource
    {
        #region Class Description

        [ResourceEntry("RecaptchaResourcesTitle",
                       Value = "Recaptcha Resources",
                       Description = "The title of this class.",
                       LastModified = "2015/08/20")]
        public string RecaptchaResourcesTitle
        {
            get
            {
                return this["RecaptchaResourcesTitle"];
            }
        }

        [ResourceEntry("RecaptchaResourcesDescription",
                       Value = "Contains localizable resources for recaptcha.",
                       Description = "The description of this class.",
                       LastModified = "2015/08/20")]
        public string RecaptchaResourcesDescription
        {
            get
            {
                return this["RecaptchaResourcesDescription"];
            }
        }

        #endregion

        #region Config Property - RecaptchaSiteKey

        [ResourceEntry("RecaptchaSiteKeyTitle",
                       Value = "Recaptcha Site Key",
                       Description = "Recaptcha Site Key",
                       LastModified = "2015/08/20")]
        public string RecaptchaSiteKeyTitle
        {
            get
            {
                return this["RecaptchaSiteKeyTitle"];
            }
        }

        [ResourceEntry("RecaptchaSiteKeyDescription",
                      Value = "Recaptcha Site Key Description",
                      Description = "Recaptcha Site Key Description",
                      LastModified = "2015/08/20")]
        public string RecaptchaSiteKeyDescription
        {
            get
            {
                return this["RecaptchaSiteKeyDescription"];
            }
        }

        #endregion

        #region Config Property - RecaptchaSecretKey

        [ResourceEntry("RecaptchaSecretKeyTitle",
                    Value = "Recaptcha Secret Key",
                    Description = "Recaptcha Secret Key",
                    LastModified = "2015/08/20")]
        public string RecaptchaSecretKeyTitle
        {
            get
            {
                return this["RecaptchaSecretKeyTitle"];
            }
        }

        [ResourceEntry("RecaptchaSecretKeyDescription",
                      Value = "Recaptcha Secret Key Description",
                      Description = "Recaptcha Secret Key Description",
                      LastModified = "2015/08/20")]
        public string RecaptchaSecretKeyDescription
        {
            get
            {
                return this["RecaptchaSecretKeyDescription"];
            }
        }

        #endregion

        #region Config Property - RecaptchaTheme

        [ResourceEntry("RecaptchaThemeTitle",
                    Value = "Recaptcha Theme",
                    Description = "Recaptcha Theme",
                    LastModified = "2015/08/20")]
        public string RecaptchaThemeTitle
        {
            get
            {
                return this["RecaptchaThemeTitle"];
            }
        }

        [ResourceEntry("RecaptchaThemeDescription",
                      Value = "Recaptcha Theme - dark or light",
                      Description = "Recaptcha Theme - dark or light",
                      LastModified = "2015/08/20")]
        public string RecaptchaThemeDescription
        {
            get
            {
                return this["RecaptchaThemeDescription"];
            }
        }

        #endregion

        #region Config Property - RecaptchaType

        [ResourceEntry("RecaptchaTypeTitle",
                    Value = "Recaptcha Type",
                    Description = "Recaptcha Type",
                    LastModified = "2015/08/20")]
        public string RecaptchaTypeTitle
        {
            get
            {
                return this["RecaptchaTypeTitle"];
            }
        }

        [ResourceEntry("RecaptchaTypeDescription",
                      Value = "Recaptcha type - image or audio",
                      Description = "Recaptcha type - image or audio",
                      LastModified = "2015/08/20")]
        public string RecaptchaTypeDescription
        {
            get
            {
                return this["RecaptchaTypeDescription"];
            }
        }

        #endregion

        #region Config - Error Messages

        [ResourceEntry("NotValidCaptchaErrorMessage",
                    Value = "Captcha is not valid.",
                    Description = "Captcha is not valid.",
                    LastModified = "2015/08/20")]
        public string NotValidCaptchaErrorMessage
        {
            get
            {
                return this["NotValidCaptchaErrorMessage"];
            }
        }

        [ResourceEntry("NoCaptchaResponseErrorMessage",
                    Value = "Captcha is not set. Captcha is required.",
                    Description = "Captcha is not set. Captcha is required.",
                    LastModified = "2015/08/20")]
        public string NoCaptchaResponseErrorMessage
        {
            get
            {
                return this["NoCaptchaResponseErrorMessage"];
            }
        }

        [ResourceEntry("UsernameRequiredErrorMessage",
                    Value = "Username is required",
                    Description = "Username is required",
                    LastModified = "2015/08/20")]
        public string UsernameRequiredErrorMessage
        {
            get
            {
                return this["UsernameRequiredErrorMessage"];
            }
        }

        [ResourceEntry("PasswordRequiredErrorMessage",
                    Value = "Password is required",
                    Description = "Password is required",
                    LastModified = "2015/08/20")]
        public string PasswordRequiredErrorMessage
        {
            get
            {
                return this["PasswordRequiredErrorMessage"];
            }
        }

        #endregion

        #region Config Property - RecaptchaType

        [ResourceEntry("RecaptchaLanguageCodeTitle",
                    Value = "Recaptcha Language code",
                    Description = "Recaptcha Language code",
                    LastModified = "2015/08/20")]
        public string RecaptchaLanguageCodeTitle
        {
            get
            {
                return this["RecaptchaLanguageCodeTitle"];
            }
        }

        [ResourceEntry("RecaptchaLanguageCodeDescription",
                      Value = "Recaptcha Language code, see https://developers.google.com/recaptcha/docs/language",
                      Description = "Recaptcha Language code, see https://developers.google.com/recaptcha/docs/language",
                      LastModified = "2015/08/20")]
        public string RecaptchaLanguageCodeDescription
        {
            get
            {
                return this["RecaptchaLanguageCodeDescription"];
            }
        }

        #endregion
    }
}

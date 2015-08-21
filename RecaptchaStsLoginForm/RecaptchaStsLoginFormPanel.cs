using Telerik.Sitefinity.Security.Web.UI;

namespace RecaptchaBackendLogin.RecaptchaStsLoginForm
{
    public class RecaptchaStsLoginFormPanel : StsLoginFormPanel
    {
        protected override void CreateViews()
        {
            AddView<RecaptchaStsLoginForm>();
        }
    }
}
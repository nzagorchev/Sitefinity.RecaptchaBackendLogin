using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Security.Web.UI;
using Telerik.Sitefinity.Web.UI;

namespace RecaptchaBackendLogin.RecaptchaStsLoginForm
{
    public class RecaptchaStsLoginForm : StsLoginForm
    {
        public override string LayoutTemplatePath
        {
            get
            {
                return RecaptchaStsLoginForm.layoutTemplatePath;
            }
        }

        public virtual HtmlInputText UserNameInput
        {
            get
            {
                return this.Container.GetControl<HtmlInputText>("wrap_name", true);
            }
        }

        public virtual TextBox PasswordInput
        {
            get
            {
                return this.Container.GetControl<TextBox>("wrap_password", true);
            }
        }

        protected override void InitializeControls(GenericContainer container, Telerik.Sitefinity.Web.UI.ContentUI.Contracts.IContentViewDefinition definition)
        {
            this.SetBrowserAutocomplete();

            base.InitializeControls(container, definition);
        }

        protected virtual void SetBrowserAutocomplete()
        {
            bool disableBrowserAutocomplete = Telerik.Sitefinity.Configuration.Config.Get<Telerik.Sitefinity.Security.Configuration.LoginConfig>()
                   .DisableBrowserAutocomplete;

            if (disableBrowserAutocomplete)
            {
                string autocompleteAttrName = "autocomplete";
                string autocompleteValueOff = "off";
                this.UserNameInput.Attributes.Add(autocompleteAttrName, autocompleteValueOff);
                this.PasswordInput.Attributes.Add(autocompleteAttrName, autocompleteValueOff);
            }
        }

        private static readonly string layoutTemplatePath = "~/recaptchaLogin/RecaptchaBackendLogin.RecaptchaStsLoginForm.RecaptchaStsLoginForm.ascx";
    }
}
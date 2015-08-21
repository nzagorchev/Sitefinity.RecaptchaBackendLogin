using RecaptchaBackendLogin.RecaptchaStsLoginForm;
using System;
using System.Linq;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Abstractions.VirtualPath.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Modules.Pages.Configuration;
using Telerik.Sitefinity.Security.Web.UI;
using Telerik.Sitefinity.Services;

namespace RecaptchaBackendLogin
{
    public class RecaptchaModule : IModule
    {
        Guid moduleId = new Guid("{3D113D67-0F63-442E-AD97-330DD702E333}");
        public const string ModuleName = "RecaptchaModule";

        public Guid ModuleId
        {
            get { return this.moduleId; }
        }

        public string Name
        {
            get { return RecaptchaModule.ModuleName; }
        }

        public string Title
        {
            get { return RecaptchaModule.ModuleName; }
        }

        public string Description
        {
            get { return RecaptchaModule.ModuleName; }
        }

        public string ClassId
        {
            get { return null; }
        }

        public Guid LandingPageId
        {
            get { return Guid.NewGuid(); }
        }

        public StartupType Startup
        {
            get
            {
                return StartupType.OnApplicationStart;
            }
            set { }
        }

        public bool IsApplicationModule
        {
            get 
            { 
                return true;
            }
        }

        public void Initialize(ModuleSettings settings)
        {
            Res.RegisterResource<RecaptchaResources>();

            Config.RegisterSection<RecaptchaConfig>();

            Bootstrapper.Initialized += Bootstrapper_Initialized;
        }

        internal void Bootstrapper_Initialized(object sender, Telerik.Sitefinity.Data.ExecutedEventArgs e)
        {
            if (e.CommandName == "Bootstrapped")
            {
                RecaptchaSecurityTokenServiceHttpHandler.Register();
            }
        }

        public void Install(Telerik.Sitefinity.Abstractions.SiteInitializer initializer, Version upgradeFrom)
        {
            var config = initializer.Context.GetConfig<ToolboxesConfig>();
            var pageControls = config.Toolboxes["PageControls"];

            var section = pageControls.Sections
                .Where<ToolboxSection>(e => e.Name == "Login")
                .FirstOrDefault();

            // recaptcha control
            string controlName = typeof(RecaptchaStsLoginFormPanel).Name;

            if (!section.Tools.Any<ToolboxItem>(e => e.Name == controlName))
            {
                var recaptchaPanel = new ToolboxItem(section.Tools)
                {
                    Name = controlName,
                    Title = controlName,
                    Description = controlName,
                    ControlType = typeof(RecaptchaStsLoginFormPanel).AssemblyQualifiedName
                };
                section.Tools.Add(recaptchaPanel);
            }

            // default control
            string controlNameDefault = typeof(StsLoginFormPanel).Name;

            if (!section.Tools.Any<ToolboxItem>(e => e.Name == controlNameDefault))
            {
                var recaptchaPanelDefault = new ToolboxItem(section.Tools)
                {
                    Name = controlNameDefault,
                    Title = controlNameDefault,
                    Description = controlNameDefault,
                    ControlType = typeof(StsLoginFormPanel).AssemblyQualifiedName
                };
                section.Tools.Add(recaptchaPanelDefault);
            }

            var virtualPathConfig = initializer.Context.GetConfig<VirtualPathSettingsConfig>();
            if (!virtualPathConfig.VirtualPaths.Elements.Any(vp => vp.VirtualPath == "~/recaptchaLogin/*"))
            {
                var moduleVirtualPathConfig = new VirtualPathElement(virtualPathConfig.VirtualPaths)
                {
                    VirtualPath = "~/recaptchaLogin/*",
                    ResolverName = "EmbeddedResourceResolver",
                    ResourceLocation = "RecaptchaBackendLogin"
                };
                virtualPathConfig.VirtualPaths.Add(moduleVirtualPathConfig);
            }
        }

        public void Load()
        {
        }

        public void Unload()
        {
        }

        public void Uninstall(Telerik.Sitefinity.Abstractions.SiteInitializer initializer)
        {
        }

        public Telerik.Sitefinity.Web.UI.Backend.IControlPanel GetControlPanel()
        {
            return null;
        }

        public Type[] Managers
        {
            get { return null; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;

namespace RecaptchaBackendLogin
{
    public class RecaptchaConfig : ConfigSection
    {
        [ConfigurationProperty("RecaptchaSiteKey")]
        [ObjectInfo(typeof(RecaptchaResources), Title = "RecaptchaSiteKeyTitle", Description = "RecaptchaSiteKeyDescription")]
        public string RecaptchaSiteKey
        {
            get
            {
                return (string)this["RecaptchaSiteKey"];
            }

            set
            {
                this["RecaptchaSiteKey"] = value;
            }
        }

        [ConfigurationProperty("RecaptchaSecretKey")]
        [ObjectInfo(typeof(RecaptchaResources), Title = "RecaptchaSecretKeyTitle", Description = "RecaptchaSecretKeyDescription")]
        public string RecaptchaSecretKey
        {
            get
            {
                return (string)this["RecaptchaSecretKey"];
            }

            set
            {
                this["RecaptchaSecretKey"] = value;
            }
        }

        [ConfigurationProperty("RecaptchaTheme", DefaultValue = "light")]
        [ObjectInfo(typeof(RecaptchaResources), Title = "RecaptchaThemeTitle", Description = "RecaptchaThemeDescription")]
        public string RecaptchaTheme
        {
            get
            {
                return (string)this["RecaptchaTheme"];
            }

            set
            {
                this["RecaptchaTheme"] = value;
            }
        }

        [ConfigurationProperty("RecaptchaType", DefaultValue = "image")]
        [ObjectInfo(typeof(RecaptchaResources), Title = "RecaptchaTypeTitle", Description = "RecaptchaTypeDescription")]
        public string RecaptchaType
        {
            get
            {
                return (string)this["RecaptchaType"];
            }

            set
            {
                this["RecaptchaType"] = value;
            }
        }

        [ConfigurationProperty("RecaptchaLanguageCode")]
        [ObjectInfo(typeof(RecaptchaResources), Title = "RecaptchaLanguageCodeTitle", Description = "RecaptchaLanguageCodeDescription")]
        public string RecaptchaLanguageCode
        {
            get
            {
                return (string)this["RecaptchaLanguageCode"];
            }

            set
            {
                this["RecaptchaLanguageCode"] = value;
            }
        }
    }
}
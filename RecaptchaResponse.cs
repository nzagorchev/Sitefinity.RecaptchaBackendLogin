using Newtonsoft.Json;

namespace RecaptchaBackendLogin
{
    public class RecaptchaResponse
    {
        public bool Success { get; set; }
        [JsonProperty("error-codes")]
        public string[] ErrorCodes { get; set; }
    }
}
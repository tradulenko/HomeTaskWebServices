using Newtonsoft.Json;

namespace HomeTaskWebServices.Api_Interactions.Dto.responseDto
{
    public class AuthToken
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}

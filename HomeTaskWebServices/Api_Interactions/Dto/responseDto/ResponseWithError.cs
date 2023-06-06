using Newtonsoft.Json;

namespace HomeTaskWebServices.Api_Interactions.Dto.responseDto
{
    public class ResponseWithError
    {
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}

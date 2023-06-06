using Newtonsoft.Json;

namespace HomeTaskWebServices.Api_Interactions.Dto.responseDto.bookingDTO
{
    internal class BookingIdDto
    {
        [JsonProperty("bookingid")]
        public string BookingId { get; set; }
    }
}

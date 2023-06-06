using System.Text.Json.Serialization;

namespace HomeTaskWebServices.Api_Interactions.Dto.requestDto.bookingDTO
{
    public class BookingDatesDto
    {
        [JsonPropertyName("checkin")]
        public string CheckIn { get; set; }

        [JsonPropertyName("checkout")]
        public string CheckOut { get; set; }
    }
}

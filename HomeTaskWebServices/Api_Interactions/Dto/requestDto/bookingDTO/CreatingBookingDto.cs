using System.Text.Json.Serialization;

namespace HomeTaskWebServices.Api_Interactions.Dto.requestDto.bookingDTO
{
    public class CreatingBookingDto
    {
        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastname")]
        public string LastName { get; set; }

        [JsonPropertyName("totalprice")]
        public decimal TotalPrice { get; set; }

        [JsonPropertyName("depositpaid")]
        public bool DepositPaid { get; set; }

        [JsonPropertyName("bookingdates")]
        public BookingDatesDto BookingDates { get; set; }

        [JsonPropertyName("additionalneeds")]
        public string AdditionalNeeds { get; set; }
    }
}

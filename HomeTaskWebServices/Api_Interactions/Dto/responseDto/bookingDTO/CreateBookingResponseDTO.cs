using HomeTaskWebServices.Api_Interactions.Dto.requestDto.bookingDTO;
using Newtonsoft.Json;

namespace HomeTaskWebServices.Api_Interactions.Dto.responseDto.bookingDTO
{
    public class CreatingBookingResponseDTO
    {
        [JsonProperty("bookingid")]
        public int BookingId { get; set; }

        [JsonProperty("booking")]
        public BookingDto Booking { get; set; }
    }

    public class BookingDto
    {
        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("totalprice")]
        public decimal TotalPrice { get; set; }

        [JsonProperty("depositpaid")]
        public bool DepositPaid { get; set; }

        [JsonProperty("bookingdates")]
        public BookingDatesDto BookingDates { get; set; }

        [JsonProperty("additionalneeds")]
        public string AdditionalNeeds { get; set; }
    }


}

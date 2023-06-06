using HomeTaskWebServices.Api_Interactions.Dto.requestDto.bookingDTO;
using HomeTaskWebServices.Api_Interactions.Dto.responseDto.bookingDTO;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using Shouldly;
using System.Net;

namespace HomeTaskWebServices.Api_Interactions.Api
{
    internal class Booking : BaseApi
    {
        public List<BookingIdDto> GetBookingIds(string firstname = null, string lastname = null, string checkin = null, string checkout = null, DateTime? checkinDate = null, DateTime? checkoutDate = null)
        {
            if (checkinDate.HasValue)
                checkin = checkinDate.Value.ToString("yyyy-MM-dd");

            if (checkoutDate.HasValue)
                checkout = checkoutDate.Value.ToString("yyyy-MM-dd");

            RestRequest request = new RestRequest(EndPoints.EndPoints.BOOKING);

            if (!string.IsNullOrEmpty(firstname))
                request.AddQueryParameter("firstname", firstname);

            if (!string.IsNullOrEmpty(lastname))
                request.AddQueryParameter("lastname", lastname);

            if (!string.IsNullOrEmpty(checkin))
                request.AddQueryParameter("checkin", checkin);

            if (!string.IsNullOrEmpty(checkout))
                request.AddQueryParameter("checkout", checkout);

            RestResponse response = client.Execute(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            List<BookingIdDto> bookings = JsonConvert.DeserializeObject<List<BookingIdDto>>(response.Content);
            return bookings;
        }

        public RestResponse CreatingBooking(CreatingBookingDto creatingBookingDto)
        {
            RestRequest request = new RestRequest(EndPoints.EndPoints.BOOKING, Method.Post);
            request.AddJsonBody(creatingBookingDto);
            AddHeaders(request);

            return client.Execute(request);
        }
        public CreatingBookingResponseDTO CreatingBookingAndReturnCreatedOne(CreatingBookingDto creatingBookingDto)
        {
                                   
            RestResponse response = CreatingBooking(creatingBookingDto);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            CreatingBookingResponseDTO creatingBookingResponseDTO = JsonConvert.DeserializeObject<CreatingBookingResponseDTO>(response.Content);
            return creatingBookingResponseDTO;
        }


        public void AssertCreatedBook(CreatingBookingResponseDTO creatingBookingResponseDTO)
        {

            CreatingBookingDto expectedData = Data.MyBooking.mySecondCreatingBookingDto;

            creatingBookingResponseDTO.ShouldSatisfyAllConditions(
                    () => creatingBookingResponseDTO.Booking.FirstName.ShouldBe(expectedData.FirstName),
                    () => creatingBookingResponseDTO.Booking.LastName.ShouldBe(expectedData.LastName),
                    () => creatingBookingResponseDTO.Booking.TotalPrice.ShouldBe(expectedData.TotalPrice),
                    () => creatingBookingResponseDTO.Booking.BookingDates.CheckIn.ShouldBe(expectedData.BookingDates.CheckIn),
                    () => creatingBookingResponseDTO.Booking.BookingDates.CheckOut.ShouldBe(expectedData.BookingDates.CheckOut),
                    () => creatingBookingResponseDTO.Booking.DepositPaid.ShouldBe(expectedData.DepositPaid),
                    () => creatingBookingResponseDTO.Booking.AdditionalNeeds.ShouldBe(expectedData.AdditionalNeeds)
                );
        }

        public void DeleteBookingById(int idForDeleting)
        {
            RestRequest request = new RestRequest(EndPoints.EndPoints.BOOKING_ID, Method.Delete);
            request.AddUrlSegment("id", idForDeleting);
            AddHeaders(request);
            AddAuthorisation(request);
            RestResponse response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

        }
    }
}

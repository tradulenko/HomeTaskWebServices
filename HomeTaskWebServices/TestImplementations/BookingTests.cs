
using HomeTaskWebServices.Api_Interactions.Api;
using HomeTaskWebServices.Api_Interactions.Dto.responseDto.bookingDTO;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestSharp;

using System.Net;


namespace HomeTaskWebServices.TestImplementations
{
    [AllureNUnit]
    [TestFixture]
    public class BookingTests
    {
        Booking bookingApi = new Booking();
        CreatingBookingResponseDTO creatingBookingResponseDTO;

        [OneTimeSetUp]
        public void creatingBook()
        {
            creatingBookingResponseDTO = bookingApi.CreatingBookingAndReturnCreatedOne(Data.MyBooking.myCreatingBookingDto);
            
        }


        [Test]
        public void PositiveCaseGetAllIds()
        {
            List<BookingIdDto> response = bookingApi.GetBookingIds();
            Console.WriteLine(response.Count);
            Assert.That(response.Count, Is.GreaterThan(1));
        }

        [Test]
        public void PositiveCaseFilteringByName()
        {
            List<BookingIdDto> response = bookingApi.GetBookingIds(Data.MyBooking.myCreatingBookingDto.FirstName, Data.MyBooking.myCreatingBookingDto.LastName);
            Console.WriteLine(response.Count);
            Assert.That(response.Count, Is.GreaterThan(0));
            Assert.AreEqual(creatingBookingResponseDTO.BookingId.ToString(), response[0].BookingId);
        }


        [Ignore(reason: "API filter does not works. Manualy also")]
        [Test]
        
        public void PositiveCaseFilteringByDate()
        {
            DateTime checkin = new DateTime(2222, 1, 1);
            DateTime checkout = new DateTime(2223, 1, 1);
            List<BookingIdDto> response = bookingApi.GetBookingIds(checkinDate: checkin, checkoutDate : checkout);
            Console.WriteLine(creatingBookingResponseDTO.Booking.BookingDates.CheckIn);
            Console.WriteLine(creatingBookingResponseDTO.Booking.BookingDates.CheckOut);
            Console.WriteLine(response.Count);
            Assert.That(response.Count, Is.GreaterThan(0));
            Assert.AreEqual("1960", response[0].BookingId);
        }


        [Test]
        public void PositiveCaseCreatingBokking()
        {
            CreatingBookingResponseDTO creatingBookingResponseDTO = bookingApi.CreatingBookingAndReturnCreatedOne(Data.MyBooking.mySecondCreatingBookingDto);

            Console.WriteLine(creatingBookingResponseDTO.Booking.FirstName);
            Console.WriteLine(creatingBookingResponseDTO.BookingId);

            bookingApi.AssertCreatedBook(creatingBookingResponseDTO);

            bookingApi.DeleteBookingById(creatingBookingResponseDTO.BookingId);
        }

        [Test]
        public void NegativeCaseCreatingBokking()
        {
            RestResponse restResponse = bookingApi.CreatingBooking(Data.MyBooking.myNotValideCreatingBookingDto);

            Assert.AreEqual(HttpStatusCode.InternalServerError, restResponse.StatusCode);
            Assert.AreEqual("Internal Server Error", restResponse.Content);
        }

    }
}

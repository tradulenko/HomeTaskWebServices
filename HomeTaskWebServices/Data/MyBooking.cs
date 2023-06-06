using HomeTaskWebServices.Api_Interactions.Dto.requestDto.bookingDTO;

namespace HomeTaskWebServices.Data
{
    public class MyBooking

    {
        public static CreatingBookingDto myCreatingBookingDto = new CreatingBookingDto()
            {
                FirstName = Faker.NameFaker.FirstName() + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"),
                LastName = "Test",
                TotalPrice = 100,
                DepositPaid = true,
                BookingDates = new BookingDatesDto
                {
                    CheckIn = "2222-01-01",
                    CheckOut = "2223-01-01"
                },
                AdditionalNeeds = " No additional needs"
            };

        public static CreatingBookingDto mySecondCreatingBookingDto = new CreatingBookingDto()
        {
            FirstName = Faker.NameFaker.FirstName() + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"),
            LastName = "Test",
            TotalPrice = 100,
            DepositPaid = false,
            BookingDates = new BookingDatesDto
            {
                CheckIn = "2222-01-01",
                CheckOut = "2223-01-01"
            },
            AdditionalNeeds = " No additional needs"
        };


        public static CreatingBookingDto myNotValideCreatingBookingDto = new CreatingBookingDto()
        {

            LastName = "Test",
            TotalPrice = 100,
            DepositPaid = true,
            BookingDates = new BookingDatesDto
            {
                CheckIn = "2022-01-01",
                CheckOut = "2023-01-01"
            },
            AdditionalNeeds = " No additional needs"
        };
    }
}

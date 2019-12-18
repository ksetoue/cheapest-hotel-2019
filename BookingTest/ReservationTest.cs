using System.Collections.Generic;
using BookingDomain;
using BookingDomain.Hotels;
using Xunit;

namespace BookingDomainTests
{
    public class BookingTest
    {
        [Theory]
        [InlineData("Regular: 16Mar2009(mon), 17Mar2009(tues), 18Mar2009(wed)", "Lakewood")]
        [InlineData("Regular: 20Mar2009(fri), 21Mar2009(sat), 22Mar2009(sun)", "Bridgewood")]
        [InlineData("Rewards: 26Mar2009(thur), 27Mar2009(fri), 28Mar2009(sat)", "Ridgewood")]
        public void GetCheapestHotel_ValidInput_ReturnCheapestHotelName(string input, string expected)
        {
            //Arrange
            BookingRequest bookingRequest = BookingService.BuildBookingRequest(input);
            IList<Hotel> defaultHotels = HotelFactory.GetHotelFactory();

            //Act
            var result = Booking
                .GetCheapestHotel(bookingRequest, defaultHotels)
                .Hotel
                .Name;

            //Assert
            Assert.Equal(result, expected);
        }

    }

}
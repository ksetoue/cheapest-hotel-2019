using System.Collections.Generic;
using Booking.Reservations;
using Booking.Hotels;
using Utils;
using Xunit;

namespace BookingTests
{
    public class ReservationTest
    {
        [Theory]
        [InlineData("Regular: 16Mar2009(mon), 17Mar2009(tues), 18Mar2009(wed)", "Lakewood")]
        [InlineData("Regular: 20Mar2009(fri), 21Mar2009(sat), 22Mar2009(sun)", "Bridgewood")]
        [InlineData("Rewards: 26Mar2009(thur), 27Mar2009(fri), 28Mar2009(sat)", "Ridgewood")]
        public void GetCheapestHotel_ValidInput_ReturnCheapestHotelName(string input, string expected)
        {
            //Arrange
            ReservationRequest reservationRequest = InputParser.BuildReservationRequest(input);
            IList<Hotel> defaultHotels = HotelFactory.GetHotelFactory();

            //Act
            var result = Reservation
                .GetCheapestHotel(reservationRequest, defaultHotels)
                .Hotel
                .Name;

            //Assert
            Assert.Equal(result, expected);
        }

    }

}
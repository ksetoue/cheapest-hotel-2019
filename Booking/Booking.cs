using System.Collections.Generic;
using System.Linq;
using BookingDomain.Hotels;
using BookingDomain.Dates;

namespace BookingDomain
{
    /// <summary>
    /// Class that implement methods to calculate costs of hotels based on BookingRequest 
    /// </summary>
    public static class Booking
    {
        /// <summary>
        /// Method that is used to get the cheapest hotel for a Booking request
        /// </summary>
        /// <param name="bookingRequest">Booking request object that contains customer type and dates</param>
        /// <param name="hotels">List of hotels</param>
        /// <returns></returns>
        public static HotelBooking GetCheapestHotel(BookingRequest bookingRequest, IList<Hotel> hotels)
        {
            return hotels
                .Select(hotel => GetHotelBooking(hotel, bookingRequest))
                .OrderBy(h => h, new PriceComparer())
                .FirstOrDefault();
        }

        /// <summary>
        /// Method that calculates hotel price for a sequence of dates 
        /// </summary>
        /// <param name="hotel">object that describes a hotel</param>
        /// <param name="request">request that contains a list of dates and customer type</param>
        /// <returns></returns>
        public static HotelBooking GetHotelBooking(Hotel hotel, BookingRequest request)
        {
            double hotelPrice = 0d;

            foreach(var date in request.Dates)
            {
                bool isWeekend = WeekDay.sun == date || WeekDay.sat == date; 
                bool isRewards = request.CustomerType == "Rewards";
                
                hotelPrice += hotel.GetHotelCostByDay(isWeekend, isRewards);

            }
            
            return new HotelBooking(){
                Hotel = hotel,
                Cost = hotelPrice
            };
        }
    }
}
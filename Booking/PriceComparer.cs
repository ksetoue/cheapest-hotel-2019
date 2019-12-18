using System.Collections.Generic;
using BookingDomain.Hotels;

namespace BookingDomain
{
    public class PriceComparer : IComparer<HotelBooking>
    {
        /// <summary>
        /// method that compares two hotel cost values.Used to detect draws.
        /// </summary>
        /// <param name="x">cost of fist item</param>
        /// <param name="y">cost of second item</param>
        /// <returns>returns if cost is equal</returns>
        public int Compare(HotelBooking x, HotelBooking y)
        {
            // compare decreasing values
            if (x.Cost == y.Cost) {
                return y.Hotel.Classification.CompareTo(x.Hotel.Classification);
            }
            return x.Cost.CompareTo(y.Cost);

        }
    }
}
using System;
using System.Collections.Generic;
using BookingDomain.Hotels;
using BookingDomain.Dates;

namespace BookingDomain
{
    public class BookingRequest : IEquatable<BookingRequest>
    {
        public string CustomerType { get; set; }
        public IList<WeekDay> Dates { get; set; }

        /// <summary>
        /// Method that overrides the comparison between items of BookingRequest - used on test classes to compare objects
        /// </summary>
        /// <param name="x">entry that is being compared</param>
        /// <returns>return if the object compared is equal</returns>
        public bool Equals(BookingRequest x)
        {
            return GetHashCode() == x.GetHashCode();
        }

        /// <summary>
        /// Method that returns a hash code for Customer type, used on comparison method
        /// </summary>
        /// <returns>Returns a hash code</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(CustomerType, GetListHashCode());
        }

        /// <summary>
        /// Method that verifies the correct hash code of a date object
        /// </summary>
        /// <returns>returns the correspondent item</returns>
        public int GetListHashCode ()
        {
            int previous = 0; 

            foreach(var date in Dates)
            {
                previous = HashCode.Combine(previous, date);
            }

            return previous;
        }
    }
}
using System;

namespace BookingDomain.Dates
{
    public class InvalidWeekDayException : Exception
    {
        /// <summary>
        /// Method that implements an exception for wrong inputs of dates
        /// </summary>
        /// <param name="message">message of the exception</param>
        /// <param name="e">exception</param>
        /// <returns></returns>
        public InvalidWeekDayException(string message, Exception e = null) : base(message, e)
        {
            
        }
    }
}
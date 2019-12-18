using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using BookingDomain;
using BookingDomain.Dates;

namespace BookingDomain
{
    /// <summary>
    /// Helper to build booking requests
    /// </summary>
    public class BookingService 
    {
        /// <summary>
        /// builds a single booking request, that is used to mount the object
        /// </summary>
        /// <param name="input">String that describes a booking request</param>
        /// <returns>an object of a booking request</returns>
        public static BookingRequest BuildBookingRequest(string input)
        {
            BookingRequest bookingRequest = new BookingRequest();
            string[] result;

            // split by :
            result = input.Split(":", StringSplitOptions.None);

            foreach(string item in result)
            {
                if(item == "Regular") 
                {
                    bookingRequest.CustomerType = "Regular";
                }
                else if (item == "Rewards") 
                {
                    bookingRequest.CustomerType = "Rewards";
                } 
                else 
                {
                    bookingRequest.Dates = GetListOfDates(item);
                }
            }

            return bookingRequest;
        }

        /// <summary>
        /// This method is used to generate a list of booking requests, 
        /// that will be used to process the cheapest hotel for that request
        /// </summary>
        /// <param name="input">List of booking request strings</param>
        /// <returns>list of bookingRequest objects</returns>
        public static IList<BookingRequest> BuildSearchRequest(IList<string> input)
        {
            
            List<BookingRequest> requests = new List<BookingRequest>();

            foreach(string line in input)
            {
                BookingRequest bookingRequest = BuildBookingRequest(line);               
                requests.Add(bookingRequest);
            }

            return requests;
        }


        /// <summary>
        /// Helper to parse a string of dates into a list of WeekDay enum.
        /// it will be used to calculate the cost of each hotel, based on day type - weekday or weekend
        /// </summary>
        /// <param name="dayStrings">string of dates</param>
        /// <returns>List of days on WeekDay format</returns>
        public static IList<WeekDay> GetListOfDates(string dayStrings)
        {
            List<WeekDay> dateTypes = new List<WeekDay>();
            string pattern = @"\(([\w]{1,})\)";
            
            string[] days = dayStrings.Split(",", StringSplitOptions.RemoveEmptyEntries);
            
            foreach(string day in days) {
                foreach(Match match in Regex.Matches(day, pattern)) {
                    // match.Groups get the value inside the regex. Ex: (mon) --> mon
                    if(match.Groups[1] != null) {
                        try
                        {
                            var weekday = (WeekDay)Enum.Parse(typeof(WeekDay), match.Groups[1].Value);
                            dateTypes.Add(weekday);
                        } 
                        catch(ArgumentException e)
                        {
                            throw new InvalidWeekDayException($"Invalid weekday name: {match.Groups[1]}", e);
                        }
                    }
                }

            }
            return dateTypes;
        }

    }
}
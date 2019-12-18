// quando passar um dia errado, retornar um invalid week day exception

using System;
using System.Collections.Generic;
using BookingDomain;
using BookingDomain.Dates;
using Xunit;

namespace SearchCoreTests
{   
    public class InputParserTest
    {
        /// <summary>
        /// Private method that gets a mock weekDay object for testing
        /// </summary>
        /// <param name="dates">string of dates</param>
        /// <returns>Returns a WeekDay object</returns>
        private IList<WeekDay> getWeekDaysForTest(string dates)
        {
            IList<WeekDay> daysExpected = new List<WeekDay>();            
            var stringDays = dates.Split(",");

            foreach(var day in stringDays)
            {
                daysExpected.Add((WeekDay)Convert.ToInt32(day));
            }

            return daysExpected;
        }

        [Theory]
        [InlineData("Regular: 16Mar2009(mon), 17Mar2009(tues), 18Mar2009(wed)", "Regular", "1,2,3")]
        [InlineData("Regular: 20Mar2009(fri), 21Mar2009(sat), 22Mar2009(sun)", "Regular", "5,6,7")]
        [InlineData("Rewards: 26Mar2009(thur), 27Mar2009(fri), 28Mar2009(sat)", "Rewards", "4,5,6")]
        public void BuildReservationRequest_ValidInput_ReturnsValidReservationRequest(string input, string customerExpected, string daysExpected)
        {
            //Arrange
            IList<WeekDay> daysExp = getWeekDaysForTest(daysExpected);

            BookingRequest expected = new BookingRequest(); 
            expected.CustomerType = customerExpected;
            expected.Dates = daysExp;

            //Act
            BookingRequest result = BookingService.BuildBookingRequest(input);
            
            //Assert
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData("16Mar2009(mon), 17Mar2009(tues), 18Mar2009(wed)", "1,2,3")]
        [InlineData("20Mar2009(fri), 21Mar2009(sat), 22Mar2009(sun)", "5,6,7")]
        [InlineData("26Mar2009(thur), 27Mar2009(fri), 28Mar2009(sat)", "4,5,6")]
        [InlineData("26Mar2009(thur)", "4")]
        public void GetListOfDates_ValidInput_ReturnWeekDayList(string input, string dayStrings)
        {
            //Arrange
            IList<WeekDay> expected = getWeekDaysForTest(dayStrings);

            //Act
            IList<WeekDay> result = BookingService.GetListOfDates(input);

            //Assert
            Assert.Equal(result, expected);
        }

        [Fact]
        public void GetListOfDates_InvalidInput_ThrowsInvalidWeekDayException()
        {
            //Arrange 
            string date = "16Mar2009(mob)";
            Action result = () => BookingService.GetListOfDates(date);

            //Act

            //Assert
            Assert.Throws<InvalidWeekDayException>(result);
        }
    }
}
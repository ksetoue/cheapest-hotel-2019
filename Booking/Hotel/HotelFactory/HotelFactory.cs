using System;
using System.Collections.Generic;

namespace BookingDomain.Hotels
{
    public static class HotelFactory
    {       

        /// <summary>
        /// This method is used to generate mock of default hotels.
        /// </summary>
        /// <returns>list of Hotels</returns>
        public static IList<Hotel> GetHotelFactory() 
        {
            Hotel Lakewood = new Hotel {
                Name = "Lakewood",
                TaxWeekRegular = 110.00,
                TaxWeekReward = 80,
                TaxWeekendRegular = 90,
                TaxWeekendReward = 80,
                Classification = 3
            };

            Hotel Bridgewood = new Hotel {
                Name = "Bridgewood",
                TaxWeekRegular = 160.00,
                TaxWeekReward = 110,
                TaxWeekendRegular = 60,
                TaxWeekendReward = 50,
                Classification = 4
            };

            Hotel Ridgewood = new Hotel {
                Name = "Ridgewood",
                TaxWeekRegular = 220.00,
                TaxWeekReward = 100,
                TaxWeekendRegular = 150,
                TaxWeekendReward = 40,
                Classification = 5
            };
            IList<Hotel> listOfHotels = new List<Hotel>();

            listOfHotels.Add(Lakewood);
            listOfHotels.Add(Bridgewood);
            listOfHotels.Add(Ridgewood);

            return listOfHotels;
        }
    }
}
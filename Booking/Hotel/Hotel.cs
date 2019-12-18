using System;

namespace BookingDomain.Hotels
{
    public class Hotel
    {
        
        private string _name;
        private int _classification;
        private double _taxWeekRegular;
        private double _taxWeekendRegular;
        private double _taxWeekReward;
        private double _taxWeekendReward;
    
        public string Name {
            get { return _name; }
            set { _name = value; } 
        } 

        public int Classification {
            get { return _classification; }
            set { _classification = value; } 
        } 

        public double TaxWeekRegular {
            get { return _taxWeekRegular; }
            set { _taxWeekRegular = value; } 
        } 

        public double TaxWeekendRegular {
            get { return _taxWeekendRegular; }
            set { _taxWeekendRegular = value; } 
        } 

        public double TaxWeekReward {
            get { return _taxWeekReward; }
            set { _taxWeekReward = value; } 
        }
        

        /// <summary>
        /// This method is used to get the cost for a specific day.
        /// </summary>
        /// <param name="isWeekend">boolean that says if the day is saturday or sunday</param>
        /// <param name="isRewards">boolean that specifies if a customer is </param>
        /// <returns>returns the correspondent tax</returns>
        public double GetHotelCostByDay(bool isWeekend, bool isRewards)
        {
            if(isWeekend && !isRewards) 
            {
                return this.TaxWeekendRegular;
            }
            else if (!isWeekend && !isRewards)
            {
                return this.TaxWeekRegular;
            }
            else if (isWeekend && isRewards)
            {
                return this.TaxWeekendReward;
            }

            return this.TaxWeekReward;       

        }

        public double TaxWeekendReward {
            get { return _taxWeekendReward; }
            set { _taxWeekendReward = value; } 
        } 

        public Hotel() {}
    }
}
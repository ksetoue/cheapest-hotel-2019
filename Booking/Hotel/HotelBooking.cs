namespace BookingDomain.Hotels
{
    /// <summary>
    /// Class that defines the relationship between Hotels and booking requests
    /// </summary>
    public class HotelBooking
    {
        public Hotel Hotel { get; set; }

        public double Cost { get; set; } 
    }
}
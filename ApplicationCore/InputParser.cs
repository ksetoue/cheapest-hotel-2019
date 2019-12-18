using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BookingDomain;
using BookingDomain.Hotels;

namespace ApplicationCore
{
    /// <summary>
    /// Reads lines from the input file and calculates the cost of a booking request
    /// </summary>
    public class InputParser 
    {
        public List<string> ReadStream() 
        {
            string line;
            List<string> lines = new List<string>();
            System.IO.StreamReader fileName = new System.IO.StreamReader($@"{Directory.GetCurrentDirectory()}/assets/input.txt");

            // reads input file and add it to the lines list
            while((line = fileName.ReadLine()) != null) 
            {
                lines.Add(line);
            }

            fileName.Close();
            return lines;
        }

        public void PrintOutput(List<string> lines)
        {
            var requests = BookingService.BuildSearchRequest(lines);
            var result = requests.Select(_ => Booking.GetCheapestHotel(_, HotelFactory.GetHotelFactory()));

            foreach(var hotel in result)
            {
                Console.WriteLine($"{hotel.Hotel.Name}");
            }
        }
    }
}
using System.Collections.Generic;

namespace ApplicationCore
{
    /// <summary>
    /// Program that prints a Hotel name for each input line on input file 
    /// </summary>
    class Program
    {

        /// <summary>
        /// Main method of the application.
        /// Calls readStream that reads inputfile and prints the result
        /// </summary>
        static void Main(string[] args)
        {
            InputParser input = new InputParser();
            List<string> inputLines = input.ReadStream();
            input.PrintOutput(inputLines);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AnkamaTechTest2
{
    public class Player
    {
        public int GetNumericInput()
        {
            try
            {
                var userInput = Console.ReadLine();
                return int.Parse(userInput);
            }
            catch (Exception)
            {
                Console.WriteLine("Please provide a numeric value.");
                return -1;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Domain.Helpers
{
    public static class HelpfulFunctions
    {
        public static int IntegerInput()
        {
            while (true)
            {
                try
                {
                    var Integer = int.Parse(Console.ReadLine());
                    return Integer;
                }
                catch
                {
                    Console.WriteLine("Možete unijeti samo broj!");
                }
            }
        }
    }
}

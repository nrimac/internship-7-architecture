using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Presentation.Helpers
{
    public static class ReadHelper
    {
        public static int IntegerInput()
        {
            do
            {
                var isInteger = int.TryParse(Console.ReadLine(), out var integer);

                if (isInteger)
                {
                    return integer;
                }

                Console.WriteLine("Please input a number.");
            } while (true);
        }
    }
}

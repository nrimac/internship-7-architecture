using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointOfSale.Data.Enums;
using System.Threading;

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

        public static bool IsNotNullOrEmpty(out string stringValue)
        {
            var readLine = Console.ReadLine();

            if (string.IsNullOrEmpty(readLine))
            {
                stringValue = null;
                return false; 
            }

            stringValue = readLine;
            return true;
        }

        public static OfferType ChooseTypeOfOffer()
        {
            Console.WriteLine("1. Article\n" +
                    "2. Service\n" +
                    "3. Lease");

            var userChoice = IntegerInput();

            do
            {
                switch (userChoice)
                {
                    case 1:
                        return OfferType.Article;
                    case 2:
                        return OfferType.Service;
                    case 3:
                        return OfferType.Lease;
                    default:
                        Console.WriteLine("Not an available option!");
                        Thread.Sleep(1000);
                        break;
                }

                userChoice = IntegerInput();

            } while (true);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointOfSale.Data.Entities.Models;

namespace PointOfSale.Presentation.Helpers
{
    public static class WriteHelper
    {
        public static void PrintArticle(Article article)
        {
            Console.WriteLine($"Id:{article.Id} Name:{article.Name} Cost:{article.Cost} Amount:{article.Count}");
        }

        public static void PrintArticles(ICollection<Article> articles)
        {
            foreach (var article in articles)
            {
                PrintArticle(article);
            }
        }

        public static void PrintService(Service service)
        {
            Console.WriteLine($"Id:{service.Id} Name:{service.Name} Hourly rate:{service.HourlyRates}");
        }

        public static void PrintServices(ICollection<Service> services)
        {
            foreach (var service in services)
            {
                PrintService(service);
            }
        }
        public static void PrintLease(Lease lease)
        {
            Console.WriteLine($"Id:{lease.Id} Name:{lease.Name} Hourly rate:{lease.DailyRates}");
        }

        public static void PrintLeases(ICollection<Lease> leases)
        {
            foreach (var lease in leases)
            {
                PrintLease(lease);
            }
        }
    }
}

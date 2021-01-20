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
            Console.WriteLine($"Id:{service.Id} Name:{service.Name} Hourly rate:{service.HourlyRates} Number of required workers:{service.NumberOfWorkersNeeded}");
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

        public static void PrintCategory(Category category)
        {
            Console.WriteLine($"Id:{category.Id} Name:{category.Name}");
        }

        public static void PrintCategories(ICollection<Category> categories)
        {
            foreach (var category in categories)
            {
                PrintCategory(category);
            }
        }

        public static void PrintOffers(ICollection<Offer> offers)
        {
            foreach (var offer in offers)
            {
                Console.Write($"Offer Id:{offer.Id} ");

                if (offer.ArticleId is not null)
                {
                    PrintArticle(offer.Article);
                }
                else
                {
                    if (offer.ServiceId is not null)
                    {
                        PrintService(offer.Service);
                    }
                    else
                    {
                        if (offer.LeaseId is not null)
                        {
                            PrintLease(offer.Lease);
                        }
                    }
                } 
            }
        }

        public static void PrintArticlesAndServices(ICollection<Offer> offers)
        {
            foreach (var offer in offers)
            {
                if (offer.LeaseId == null)
                {
                    Console.Write($"Offer Id:{offer.Id} ");

                    if (offer.ArticleId is not null)
                    {
                        PrintArticle(offer.Article);
                    }
                    else
                    {
                        if (offer.ServiceId is not null)
                        {
                            PrintService(offer.Service);
                        }
                    }
                }
            }
        }

        public static void PrintOneOffBill(ICollection<OfferOrder> offerOrders, int orderId)
        {
            
        }
    }
}

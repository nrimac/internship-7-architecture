using System;
using System.Collections.Generic;
using PointOfSale.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace PointOfSale.Data.Seeds
{
    public static class DataBaseSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<OneOffBill>()
                .HasData(new List<OneOffBill>
                {
                    new OneOffBill
                    {
                        Id = 1,
                        Profit = 8000,
                        DateOfIssue = DateTime.Now
                    }
                });

            builder.Entity<ServiceBill>()
                .HasData(new List<ServiceBill>
                {

                });

            builder.Entity<SubscriptionBill>()
                .HasData(new List<SubscriptionBill>
                {

                });

            builder.Entity<Order>()
                .HasData(new List<Order>
                {
                    new Order
                    {
                        Id = 1,
                        OneOffBillId = 1,
                        ServiceBillId = null,
                        SubscriptionBillId = null
                    }
                });

            builder.Entity<OfferOrder>()
                .HasData(new List<OfferOrder>
                {
                    new OfferOrder
                    {
                        Id = 1,
                        OfferId = 1,
                        OrderId = 1,
                        NumberOfSameArticle = 2
                    }
                });

            builder.Entity<Article>()
                .HasData(new List<Article>
                {
                    new Article
                    {
                        Id = 1,
                        Name = "Pila",
                        Count = 2,
                        Cost = 4000
                    },
                    new Article
                    {
                        Id = 2,
                        Name = "Vrata",
                        Count = 5,
                        Cost = 700
                    },
                    new Article
                    {
                        Id = 3,
                        Name = "Kutija",
                        Count = 12,
                        Cost = 150
                    },
                    new Article
                    {
                        Id = 4,
                        Name = "Lampa",
                        Count = 43,
                        Cost = 200
                    },
                    new Article
                    {
                        Id = 5,
                        Name = "Karte",
                        Count = 54,
                        Cost = 30
                    },
                    new Article
                    {
                        Id = 6,
                        Name = "Kamera-Nikon D350 DSLR",
                        Count = 30,
                        Cost = 2000
                    },
                    new Article
                    {
                        Id = 7,
                        Name = "Monitor-LG 27000",
                        Count = 7,
                        Cost = 1500
                    }
                });

            builder.Entity<Service>()
                .HasData(new List<Service>
                {
                    new Service
                    {
                        Id = 1,
                        Name = "Instalacija interneta",
                        HourlyRates = 20,
                        NumberOfWorkersNeeded = 1
                    },
                    new Service
                    {
                        Id = 2,
                        Name = "Instalacija klime",
                        HourlyRates = 30,
                        NumberOfWorkersNeeded = 2
                    },
                    new Service
                    {
                        Id = 3,
                        Name = "Bojanje zida",
                        HourlyRates = 40,
                        NumberOfWorkersNeeded = 1
                    }
                });

            builder.Entity<Lease>()
                .HasData(new List<Lease>
                {
                    new Lease
                    {
                        Id = 1,
                        Name = "Kombi-BMW",
                        DailyRates = 100,
                        IsActive = false
                    },
                    new Lease
                    {
                        Id = 2,
                        Name = "PC",
                        DailyRates = 50,
                        IsActive = false
                    },
                    new Lease
                    {
                        Id = 3,
                        Name = "PlayStation 4",
                        DailyRates = 30,
                        IsActive = false
                    },
                    new Lease
                    {
                        Id = 4,
                        Name = "Motor-Piaggio",
                        DailyRates = 70,
                        IsActive = false
                    }
                });

            builder.Entity<Offer>()
                .HasData(new List<Offer>
                {
                    new Offer
                    {
                        Id = 1,
                        ArticleId = 1,
                        ServiceId = null,
                        LeaseId = null,
                        CountSold = 2
                    },
                    new Offer
                    {
                        Id = 2,
                        ArticleId = 2,
                        ServiceId = null,
                        LeaseId = null,
                        CountSold = 0
                    },
                    new Offer
                    {
                        Id = 3,
                        ArticleId = 3,
                        ServiceId = null,
                        LeaseId = null,
                        CountSold = 0
                    },
                    new Offer
                    {
                        Id = 4,
                        ArticleId = 4,
                        ServiceId = null,
                        LeaseId = null,
                        CountSold = 0
                    },
                    new Offer
                    {
                        Id = 5,
                        ArticleId = 5,
                        ServiceId = null,
                        LeaseId = null,
                        CountSold = 0
                    },
                    new Offer
                    {
                        Id = 6,
                        ArticleId = 6,
                        ServiceId = null,
                        LeaseId = null,
                        CountSold = 0
                    },
                    new Offer
                    {
                        Id = 7,
                        ArticleId = 7,
                        ServiceId = null,
                        LeaseId = null,
                        CountSold = 0
                    },
                    new Offer
                    {
                        Id = 8,
                        ArticleId = null,
                        ServiceId = 1,
                        LeaseId = null,
                        CountSold = 1
                    },
                    new Offer
                    {
                        Id = 9,
                        ArticleId = null,
                        ServiceId = 2,
                        LeaseId = null,
                        CountSold = 0
                    },
                    new Offer
                    {
                        Id = 10,
                        ArticleId = null,
                        ServiceId = 3,
                        LeaseId = null,
                        CountSold = 0
                    },
                    new Offer
                    {
                        Id = 11,
                        ArticleId = null,
                        ServiceId = null,
                        LeaseId = 1,
                        CountSold = 0
                    },
                    new Offer
                    {
                        Id = 12,
                        ArticleId = null,
                        ServiceId = null,
                        LeaseId = 2,
                        CountSold = 0
                    },
                    new Offer
                    {
                        Id = 13,
                        ArticleId = null,
                        ServiceId = null,
                        LeaseId = 3,
                        CountSold = 0
                    },
                    new Offer
                    {
                        Id = 14,
                        ArticleId = null,
                        ServiceId = null,
                        LeaseId = 4,
                        CountSold = 0
                    },
                });

            builder.Entity<Worker>()
                .HasData(new List<Worker>
                {
                    new Worker
                    {
                        Id = 1,
                        FirstName = "Mate",
                        LastName = "Matić",
                        Oib = "3123131231",
                        DailyWorkHours = 8,
                        IsAvailable = true,
                        OrderId = null
                    },
                    new Worker
                    {
                        Id = 2,
                        FirstName = "Šime",
                        LastName = "Šimić",
                        Oib = "4324232",
                        DailyWorkHours = 8,
                        IsAvailable = true,
                        OrderId = null
                    },
                    new Worker
                    {
                        Id = 3,
                        FirstName = "Ivan",
                        LastName = "Ivanović",
                        Oib = "543645454",
                        DailyWorkHours = 8,
                        IsAvailable = true,
                        OrderId = null
                    },
                    new Worker
                    {
                        Id = 4,
                        FirstName = "Toni",
                        LastName = "Toničević",
                        Oib = "65436345",
                        DailyWorkHours = 8,
                        IsAvailable = true,
                        OrderId = null
                    },
                    new Worker
                    {
                        Id = 5,
                        FirstName = "Mate",
                        LastName = "Matić",
                        Oib = "3123131231",
                        DailyWorkHours = 8,
                        IsAvailable = true,
                        OrderId = null
                    },
                    new Worker
                    {
                        Id = 6,
                        FirstName = "Ana",
                        LastName = "Anić",
                        Oib = "4564635465",
                        DailyWorkHours = 8,
                        IsAvailable = true,
                        OrderId = null
                    }
                });

            builder.Entity<Category>()
                .HasData(new List<Category>
                {
                    new Category
                    {
                        Id = 1,
                        Name = "Elektrotehnika"
                    }
                });

            builder.Entity<CategoryOffer>()
                .HasData(new List<CategoryOffer>
                { 
                    new CategoryOffer
                    {
                        Id = 1,
                        CategoryId = 1,
                        OfferId = 4
                    },
                    new CategoryOffer
                    {
                        Id = 2,
                        CategoryId = 1,
                        OfferId = 6
                    },
                    new CategoryOffer
                    {
                        Id = 3,
                        CategoryId = 1,
                        OfferId = 7
                    },
                    new CategoryOffer
                    {
                        Id = 4,
                        CategoryId = 1,
                        OfferId = 8
                    },
                    new CategoryOffer
                    {
                        Id = 5,
                        CategoryId = 1,
                        OfferId = 9
                    },
                    new CategoryOffer
                    {
                        Id = 6,
                        CategoryId = 1,
                        OfferId = 12
                    },
                    new CategoryOffer
                    {
                        Id = 7,
                        CategoryId = 1,
                        OfferId = 13
                    }
                });

        }
    }
}

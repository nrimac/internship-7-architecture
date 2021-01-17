using System;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Domain.Repositories;
using PointOfSale.Data.Entities.Models;
using PointOfSale.Domain.Enums;
using PointOfSale.Presentation.Helpers;
using System.Threading;
using PointOfSale.Data.Enums;

namespace PointOfSale.Presentation.Actions.OfferActions
{
    public class OfferAddAction : IAction
    {
        private readonly OfferRepository _offerRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add Offer";
        public OfferAddAction(OfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public void Call()
        {
            
            Console.Clear();

            Console.WriteLine("Choose type of offer to add:");

            var offerChoice = ReadHelper.ChooseTypeOfOffer();

            switch (offerChoice)
            {
                case OfferType.Article:
                    var article = CreateArticle();

                    Console.WriteLine(_offerRepository.AddArticle(article));
                    return;
                case OfferType.Service:
                    var service = CreateService();

                    Console.WriteLine(_offerRepository.AddService(service));
                    return;
                case OfferType.Lease:
                    var lease = CreateLease();

                    Console.WriteLine(_offerRepository.AddLease(lease));
                    return;
                default:
                    return;
            }
            
        }

        private static Article CreateArticle()
        {
            var newArticle = new Article();

            Console.WriteLine("Name of article:");
            newArticle.Name = Console.ReadLine();

            Console.WriteLine("Number to add to inventory:");
            newArticle.Count = ReadHelper.IntegerInput();

            Console.WriteLine("Cost:");
            newArticle.Cost = ReadHelper.IntegerInput();

            return newArticle;
        }

        private static Service CreateService()
        {
            var newService = new Service();

            Console.WriteLine("Name of new service:");
            newService.Name = Console.ReadLine();

            Console.WriteLine("Hourly rate for the service:");
            newService.HourlyRates = ReadHelper.IntegerInput();

            Console.WriteLine("Number of workers needed for the service:");
            newService.NumberOfWorkersNeeded = ReadHelper.IntegerInput();

            return newService;
        }

        private static Lease CreateLease()
        {
            var newLease = new Lease();

            Console.WriteLine("Name of lease:");
            newLease.Name = Console.ReadLine();

            Console.WriteLine("Daily rates of lease:");
            newLease.DailyRates = ReadHelper.IntegerInput();

            newLease.IsActive = false;

            return newLease;
        }
    }
}

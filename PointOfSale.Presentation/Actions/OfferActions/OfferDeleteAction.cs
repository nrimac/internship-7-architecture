using System;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Domain.Repositories;
using PointOfSale.Data.Enums;
using PointOfSale.Presentation.Helpers;
using System.Threading;

namespace PointOfSale.Presentation.Actions.OfferActions
{
    public class OfferDeleteAction : IAction
    {
        private readonly OfferRepository _offerRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Delete Offer";
        public OfferDeleteAction(OfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public void Call()
        {
            Console.Clear();

            Console.WriteLine("Choose type of offer to delete:");

            var offerChoice = ReadHelper.ChooseTypeOfOffer();

            switch (offerChoice)
            {
                case OfferType.Article:
                    DeleteArticle();
                    return;
                case OfferType.Service:
                    DeleteService();
                    return;
                case OfferType.Lease:
                    DeleteLease();
                    return;
                default:
                    break;
            }
        }

        public void DeleteArticle()
        {
            if(_offerRepository.GettAllArticles().Count == 0)
            {
                Console.WriteLine("No articles to delete...");
                Thread.Sleep(1000);
                return;
            }

            WriteHelper.PrintArticles(_offerRepository.GettAllArticles());

            Console.WriteLine("Input Id of Article to delete");

            var userChoice = ReadHelper.IntegerInput();

            Console.WriteLine(_offerRepository.DeleteArticle(userChoice));
        }

        public void DeleteService()
        {
            if (_offerRepository.GettAllServices().Count == 0)
            {
                Console.WriteLine("No service to delete...");
                Thread.Sleep(1000);
                return;
            }

            WriteHelper.PrintServices(_offerRepository.GettAllServices());

            Console.WriteLine("Input Id of Service to delete");

            var userChoice = ReadHelper.IntegerInput();

            Console.WriteLine(_offerRepository.DeleteService(userChoice));
        }

        public void DeleteLease()
        {
            if (_offerRepository.GettAllLeases().Count == 0)
            {
                Console.WriteLine("No lease to delete...");
                Thread.Sleep(1000);
                return;
            }

            WriteHelper.PrintLeases(_offerRepository.GettAllLeases());

            Console.WriteLine("Input Id of Lease to delete");

            var userChoice = ReadHelper.IntegerInput();

            Console.WriteLine(_offerRepository.DeleteLease(userChoice));
        }
    }
}

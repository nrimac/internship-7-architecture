using System;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Domain.Repositories;
using PointOfSale.Data.Entities.Models;
using PointOfSale.Domain.Enums;
using PointOfSale.Presentation.Helpers;
using System.Threading;

namespace PointOfSale.Presentation.Actions.OfferActions
{
    public class OfferAddAction : IAction
    {
        private readonly OfferRepository _offerRepository;
        private int OfferChoice { get; set; }

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add Offer";
        public OfferAddAction(OfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public void Call()
        {
            do
            {
                Console.Clear();

                Console.WriteLine("1. Add article\n" +
                    "2. Add service\n" +
                    "3. Add lease");

                OfferChoice = ReadHelper.IntegerInput();

                switch (OfferChoice)
                {
                    case 1:
                        var article = CreateArticle();

                        Console.WriteLine(_offerRepository.AddArticle(article));
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Not an available option!");
                        Thread.Sleep(1000);
                        break;
                }
            } while (OfferChoice is not 1 and not 2 and not 3);
        }

        private Article CreateArticle()
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

        private Service CreateService()
        {
            var newService = new Service();

            return newService;
        }

        private Lease CreateLease()
        {
            var newLease = new Lease();

            return newLease;
        }
    }
}

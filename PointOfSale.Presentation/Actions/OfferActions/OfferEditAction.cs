using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Domain.Repositories;
using PointOfSale.Data.Entities.Models;
using PointOfSale.Presentation.Helpers;
using System.Threading;
using PointOfSale.Domain.Enums;

namespace PointOfSale.Presentation.Actions.OfferActions
{
    public class OfferEditAction : IAction
    {
        private readonly OfferRepository _offerRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Edit Offer";
        public OfferEditAction(OfferRepository offerRepository)
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
                case Data.Enums.OfferType.Article:
                    EditArticle();
                    return;
                case Data.Enums.OfferType.Service:
                    EditService();
                    return;
                case Data.Enums.OfferType.Lease:
                    EditLease();
                    return;
                default:
                    break;
            }
        }

        public void EditArticle()
        {
            var articles = _offerRepository.GettAllArticles();
            WriteHelper.PrintArticles(articles);
            Console.WriteLine("Input Id number of article to edit:");
            var userChoice = ReadHelper.IntegerInput();

            var exists = false;
            foreach (var article in articles)
            {
                if (article.Id == userChoice)
                    exists = true;
            }

            if(!exists)
            {
                Console.WriteLine(ResponseResultType.NotFound);
                return;
            }

            var editedArticle = articles.First(a => a.Id == userChoice);

            Console.WriteLine("Edit or press enter to skip");

            Console.WriteLine($"Name:({editedArticle.Name})");
            editedArticle.Name = ReadHelper.IsNotNullOrEmpty(out var newName)
                ? newName
                : editedArticle.Name;

            Console.WriteLine($"Cost:({editedArticle.Cost})");
            editedArticle.Cost = int.TryParse(Console.ReadLine(), out var newCost)
                ? newCost
                : editedArticle.Cost;

            Console.WriteLine($"Amount in inventory:({editedArticle.Count})");
            editedArticle.Count = int.TryParse(Console.ReadLine(), out var newCount)
                ? newCount
                : editedArticle.Count;

            Console.WriteLine(_offerRepository.EditArticle(userChoice, editedArticle));
        }

        public void EditService()
        {
            var services = _offerRepository.GettAllServices();
            WriteHelper.PrintServices(services);
            Console.WriteLine("Input Id number of service to edit:");
            var userChoice = ReadHelper.IntegerInput();

            var exists = false;
            foreach (var service in services)
            {
                if (service.Id == userChoice)
                    exists = true;
            }

            if (!exists)
            {
                Console.WriteLine(ResponseResultType.NotFound);
                return;
            }

            var editedService = services.First(s => s.Id == userChoice);

            Console.WriteLine("Edit or press enter to skip");

            Console.WriteLine($"Name:({editedService.Name})");
            editedService.Name = ReadHelper.IsNotNullOrEmpty(out var newName)
                ? newName
                : editedService.Name;

            Console.WriteLine($"Hourly rates:({editedService.HourlyRates})");
            editedService.HourlyRates = int.TryParse(Console.ReadLine(), out var newCost)
                ? newCost
                : editedService.HourlyRates;

            Console.WriteLine($"Number of needed workers:({editedService.NumberOfWorkersNeeded})");
            editedService.NumberOfWorkersNeeded = int.TryParse(Console.ReadLine(), out var newNumber)
                ? newNumber
                : editedService.NumberOfWorkersNeeded;

            Console.WriteLine(_offerRepository.EditService(userChoice, editedService));
        }
        public void EditLease()
        {
            var leases = _offerRepository.GettAllLeases();
            WriteHelper.PrintLeases(leases);
            Console.WriteLine("Input Id number of lease to edit:");
            var userChoice = ReadHelper.IntegerInput();

            var exists = false;
            foreach (var lease in leases)
            {
                if (lease.Id == userChoice)
                    exists = true;
            }

            if (!exists)
            {
                Console.WriteLine(ResponseResultType.NotFound);
                return;
            }

            var editedLease = leases.First(l => l.Id == userChoice);

            Console.WriteLine("Edit or press enter to skip");

            Console.WriteLine($"Name:({editedLease.Name})");
            editedLease.Name = ReadHelper.IsNotNullOrEmpty(out var newName)
                ? newName
                : editedLease.Name;

            Console.WriteLine($"Hourly rates:({editedLease.DailyRates})");
            editedLease.DailyRates = int.TryParse(Console.ReadLine(), out var newCost)
                ? newCost
                : editedLease.DailyRates;

            Console.WriteLine(_offerRepository.EditLease(userChoice, editedLease));
        }
    }
}

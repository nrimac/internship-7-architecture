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

namespace PointOfSale.Presentation.Actions.OrderActions
{
    public class OrderAddAction : IAction
    {
        private readonly OrderRepository _orderRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add Order";

        public OrderAddAction(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Call()
        {
            Console.Clear();
            Console.WriteLine("1. New One-off bill\n2. New service(s) ordered\n3. New subscription");

            var userChoice = ReadHelper.IntegerInput();

            switch (userChoice)
            {
                case 1:
                    NewOneOffBill();
                    return;
                case 2:
                    NewServiceBill();
                    return;
                case 3:
                    NewSubscription();
                    return;
                default:
                    Console.WriteLine("Not an available action");
                    Thread.Sleep(1000);
                    break;
            }
        }

        public void NewOneOffBill()
        {
            var articlesAndServices = _orderRepository.GetArticlesAndServices();

            if (articlesAndServices.Count == 0)
            {
                Console.WriteLine("No available offers");
                Thread.Sleep(1000);
            }

            var newOrderId = _orderRepository.CreateNewOneOffBill();

            var userChoice = 0;

            do
            {
                WriteHelper.PrintArticlesAndServices(articlesAndServices);

                Console.WriteLine("\nInput offer Id to add to order or input 0 to stop adding:");
                userChoice = ReadHelper.IntegerInput();

                foreach (var offer in articlesAndServices)
                {
                    if (offer.Id == userChoice && offer.ArticleId is not null)
                    {
                        Console.WriteLine(_orderRepository.AddArticleToOrder(newOrderId, userChoice));
                    }
                    else
                    {
                        if (offer.Id == userChoice && offer.ServiceId is not null)
                        {
                            Console.WriteLine("Input how many hours you want the service");
                            var numberOfHours = ReadHelper.IntegerInput();

                            Console.WriteLine(_orderRepository.AddServiceToOrder(newOrderId, userChoice, numberOfHours));
                        }
                    }
                }

            } while (userChoice != 0);

            var offerOrders = _orderRepository.GetOfferOrders();
            WriteHelper.PrintOneOffBill(offerOrders, newOrderId);
        }

        public void NewServiceBill()
        {

        }

        public void NewSubscription()
        {

        }
    }
}

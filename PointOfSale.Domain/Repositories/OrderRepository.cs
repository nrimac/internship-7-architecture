using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointOfSale.Data.Entities;
using PointOfSale.Data.Entities.Models;
using PointOfSale.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace PointOfSale.Domain.Repositories
{
    public class OrderRepository : BaseRepository
    {
        public OrderRepository(PointOfSaleDbContext dbContext) : base(dbContext)
        {
        }

        //TREBA PRIVREMENO MAKNIT AVAILABILITY NA WORKERIMA

        public int CreateNewOneOffBill()
        {
            var newBill = new OneOffBill
            {
                DateOfIssue = DateTime.Now,
                Profit = 0
            };

            DbContext.OneOffBills.Add(newBill);
            SaveChanges();

            var newOrder = new Order
            {
                OneOffBillId = newBill.Id
            };

            DbContext.Orders.Add(newOrder);
            SaveChanges();

            return newOrder.Id;
        }

        public bool EnoughWorkersAvailable(int requiredNumberOfWorkers)
        {
            var allWorkers = DbContext.Workers.ToList();

            var numberOfAvailableWorkers = 0;

            foreach (var worker in allWorkers)
            {
                if (worker.IsAvailable)
                    numberOfAvailableWorkers++;
            }

            if (numberOfAvailableWorkers >= requiredNumberOfWorkers)
                return true;
            return false;
        }

        public ResponseResultType AddServiceToOrder(int orderId, int offerId, int numberOfHours)
        {
            var serviceToAdd = DbContext.Offers.Find(offerId);
            if (!EnoughWorkersAvailable(serviceToAdd.Service.NumberOfWorkersNeeded))
                return ResponseResultType.NotEnoughWorkers;

            var order = DbContext.Orders.Find(orderId);

            order.OneOffBill.Profit += serviceToAdd.Service.HourlyRates * numberOfHours;

            var newOfferOrder = new OfferOrder
            {
                OfferId = offerId,
                OrderId = orderId
            };

            DbContext.OfferOrders.Add(newOfferOrder);

            return SaveChanges();
        }

        public ResponseResultType AddArticleToOrder(int orderId, int offerId)
        {
            var articleToAdd = DbContext.Offers.Find(offerId);

            if(articleToAdd.Article.Count == 0)
            {
                return ResponseResultType.NotEnoughInInventory;
            }

            articleToAdd.Article.Count--;

            var order = DbContext.Orders.Find(orderId);

            order.OneOffBill.Profit += articleToAdd.Article.Cost;

            var allOfferOrders = DbContext.OfferOrders.ToList();

            if (allOfferOrders.Count != 0)
            {
                foreach (var offerOrder in allOfferOrders)
                {
                    if (offerOrder.OfferId == offerId && offerOrder.OrderId == orderId)
                    {
                        offerOrder.NumberOfSameArticle++;
                        return SaveChanges();
                    }
                }
            }

            var newOfferOrder = new OfferOrder
            {
                OfferId = offerId,
                OrderId = orderId
            };

            DbContext.OfferOrders.Add(newOfferOrder);

            return SaveChanges();
        }

        public ICollection<Offer> GetArticlesAndServices()
        {
            var articlesAndServices = DbContext.Offers
                .Include(o => o.Article)
                .Include(o => o.Service)
                .ToList();

            return articlesAndServices;
        }

        public ICollection<OfferOrder> GetOfferOrders()
        {
            var offerOrders = DbContext.OfferOrders
                .Include(oo => oo.Order)
                .Include(oo => oo.Offer.Article)
                .Include(oo => oo.Offer.Service)
                .Include(oo => oo.Offer.Lease)
                .ToList();

            return offerOrders;
        }
    }
}

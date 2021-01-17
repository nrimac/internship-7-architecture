using System.Collections.Generic;
using System.Linq;
using PointOfSale.Data.Entities;
using PointOfSale.Data.Entities.Models;
using PointOfSale.Domain.Enums;

namespace PointOfSale.Domain.Repositories
{
    public class OfferRepository : BaseRepository
    {

        public OfferRepository(PointOfSaleDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType DeleteArticle(int articleId)
        {
            var article = DbContext.Articles.Find(articleId);

            if (article == null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.Offers.Remove(DbContext.Offers.Find(DbContext.Offers
                .Where(o => o.ArticleId == article.Id)
                .ToList()[0].Id));

            DbContext.Articles.Remove(article);
            return SaveChanges();
        }

        public ResponseResultType DeleteService(int serviceId)
        {
            var service = DbContext.Services.Find(serviceId);

            if (service == null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.Offers.Remove(DbContext.Offers.Find(DbContext.Offers
                .Where(o => o.ServiceId == service.Id)
                .ToList()[0].Id));

            DbContext.Services.Remove(service);
            return SaveChanges();
        }

        public ResponseResultType DeleteLease(int leaseId)
        {
            var lease = DbContext.Leases.Find(leaseId);

            if (lease == null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.Offers.Remove(DbContext.Offers.Find(DbContext.Offers
                .Where(o => o.LeaseId == lease.Id)
                .ToList()[0].Id));

            DbContext.Leases.Remove(lease);
            return SaveChanges();
        }

        public ResponseResultType AddArticle(Article article)
        {
            var articleExists = DbContext.Articles.Any(a => a.Name == article.Name);

            if (articleExists)
            {
                return ResponseResultType.AlreadyExists;
            }

            DbContext.Articles.Add(article);

            SaveChanges();

            var offer = new Offer
            {
                CountSold = 0,
                ArticleId = article.Id
            };

            DbContext.Offers.Add(offer);

            return SaveChanges();
        }

        public ResponseResultType AddService(Service service)
        {
            var serviceExists = DbContext.Services.Any(a => a.Name == service.Name);

            if (serviceExists)
            {
                return ResponseResultType.AlreadyExists;
            }

            DbContext.Services.Add(service);

            SaveChanges();

            var offer = new Offer
            {
                CountSold = 0,
                ServiceId = service.Id
            };

            DbContext.Offers.Add(offer);

            return SaveChanges();
        }

        public ResponseResultType AddLease(Lease lease)
        {
            DbContext.Leases.Add(lease);

            SaveChanges();

            var offer = new Offer
            {
                CountSold = 0,
                LeaseId = lease.Id
            };

            DbContext.Offers.Add(offer);

            return SaveChanges();
        }

        public ResponseResultType EditArticle(int articleId, Article editedArticle)
        {
            var article = DbContext.Articles.Find(articleId);

            article.Name = editedArticle.Name;
            article.Cost = editedArticle.Cost;
            article.Count = editedArticle.Count;
            return SaveChanges();
        }

        public ResponseResultType EditService(int serviceId, Service editedService)
        {
            var service = DbContext.Services.Find(serviceId);

            service.Name = editedService.Name;
            service.HourlyRates = editedService.HourlyRates;
            service.NumberOfWorkersNeeded = editedService.NumberOfWorkersNeeded;
            return SaveChanges();
        }

        public ResponseResultType EditLease(int leaseId, Lease editedLease)
        {
            var lease = DbContext.Leases.Find(leaseId);

            lease.Name = editedLease.Name;
            lease.DailyRates = editedLease.DailyRates;
            return SaveChanges();
        }

        public ICollection<Offer> GettAllOffers()
        {
            return DbContext.Offers.ToList();
        }

        public ICollection<Article> GettAllArticles()
        {
            return DbContext.Articles.ToList();
        }

        public ICollection<Service> GettAllServices()
        {
            return DbContext.Services.ToList();
        }

        public ICollection<Lease> GettAllLeases()
        {
            return DbContext.Leases.ToList();
        }
    }
}

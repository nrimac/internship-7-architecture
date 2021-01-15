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
                ArticleId = service.Id
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
                ArticleId = lease.Id
            };

            DbContext.Offers.Add(offer);

            return SaveChanges();
        }

        public ICollection<Offer> GettAll()
        {
            return DbContext.Offers.ToList();
        }
    }
}

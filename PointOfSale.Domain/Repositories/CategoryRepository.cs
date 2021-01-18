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
    public class CategoryRepository : BaseRepository
    {
        public CategoryRepository(PointOfSaleDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(Category newCategory)
        {
            if (DbContext.Categories.Any(c => c.Name == newCategory.Name))
            {
                return ResponseResultType.AlreadyExists;
            }

            DbContext.Categories.Add(newCategory);

            return SaveChanges();
        }
        public ResponseResultType Delete(int categoryId)
        {
            var categoryToDelete = DbContext.Categories.Find(categoryId);

            if (categoryToDelete == null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.Categories.Remove(categoryToDelete);
            return SaveChanges();
        }
        public ResponseResultType Edit(string newName, int categoryId)
        {
            var category = DbContext.Categories.Find(categoryId);

            if (category == null)
                return ResponseResultType.NotFound;

            category.Name = newName;
            return SaveChanges();
        }
        public ResponseResultType AddOffer(int categoryId, int offerId)
        {
            var category = DbContext.Categories.Find(categoryId);
            var offer = DbContext.Offers.Find(offerId);

            if (category == null || offer == null)
                return ResponseResultType.NotFound;

            if (DbContext.CategoryOffers.Any(co => co.OfferId == offer.Id && co.CategoryId == category.Id))
            {
                return ResponseResultType.AlreadyExists;
            }

            var newCategoryOffer = new CategoryOffer
            {
                CategoryId = category.Id,
                OfferId = offer.Id
            };

            DbContext.CategoryOffers.Add(newCategoryOffer);

            return SaveChanges();
        }
        public ResponseResultType RemoveOffer(int categoryId, int offerId)
        {
            if (DbContext.Categories.Find(categoryId) == null || DbContext.Offers.Find(offerId) == null)
                return ResponseResultType.NotFound;

            var categoryOffers = DbContext.CategoryOffers
                .Where(co => co.CategoryId == categoryId && co.OfferId == offerId)
                .ToList();

            foreach (var categoryOffer in categoryOffers)
            {
                DbContext.CategoryOffers.Remove(categoryOffer);
            }

            return SaveChanges();
        }
        public ICollection<Category> GetAll()
        {
            return DbContext.Categories.ToList();
        }
        public ICollection<Offer> GetOffers()
        {
            var allOffers = DbContext.Offers
                .Include(o => o.Article)
                .Include(o => o.Service)
                .Include(o => o.Lease)
                .ToList();

            return allOffers;
        }
        public ICollection<Offer> GetOffersInCategory(int categoryId)
        {
            if (DbContext.Categories.Find(categoryId) == null)
            {
                return null;
            }

            var categoryOfferList = DbContext.CategoryOffers
                .Where(co => co.CategoryId == categoryId)
                .ToList();

            var allOffers = GetOffers();
            var offerList = new List<Offer>();

            foreach (var offer in allOffers)
            {
                foreach (var categoryOffer in categoryOfferList)
                {
                    if (categoryOffer.OfferId == offer.Id)
                    {
                        offerList.Add(offer);
                        break;
                    }
                }
            }

            return offerList;
        }
    }
}

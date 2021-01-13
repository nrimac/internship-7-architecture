﻿using PointOfSale.Data.Entities;
using PointOfSale.Domain.Enums;

namespace PointOfSale.Domain.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly PointOfSaleDbContext DbContext;

        protected BaseRepository(PointOfSaleDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected ResponseResultType SaveChanges()
        {
            var hasChanges = DbContext.SaveChanges() > 0;
            if (hasChanges)
                return ResponseResultType.Success;

            return ResponseResultType.NoChanges;
        }
    }
}

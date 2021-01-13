using System.Collections.Generic;
using System.Linq;
using PointOfSale.Data.Entities;
using PointOfSale.Data.Entities.Models;
using PointOfSale.Domain.Enums;

namespace PointOfSale.Domain.Repositories
{
    public class CustomerRepository : BaseRepository
    {

        public CustomerRepository(PointOfSaleDbContext dbContext) : base(dbContext)
        {
        }

        
    }
}

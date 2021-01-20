using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Data.Entities.Models
{
    public class OfferOrder
    {
        public int Id { get; set; }
        public int NumberOfSameArticle { get; set; } = 0;
        public int? ServiceHours { get; set; }
        public int? LeaseDays { get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}

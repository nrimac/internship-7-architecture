using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Data.Entities.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public int CountSold { get; set; }

        public int? ArticleId { get; set; }
        public virtual Article Article { get; set; }

        public int? ServiceId { get; set; }
        public virtual Service Service { get; set; }

        public int? LeaseId { get; set; }
        public virtual Lease Lease { get; set; }

        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }

        public ICollection<CategoryOffer> CategoryOffers { get; set; }
    }
}

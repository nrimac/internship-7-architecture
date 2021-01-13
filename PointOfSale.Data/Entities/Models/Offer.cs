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
        public string Name { get; set; }

        public Article Article { get; set; }
        public Service Service { get; set; }
        public Lease Lease { get; set; }

        public int PriceId { get; set; }
        public Price Price { get; set; }

        public int BillId { get; set; }
        public Bill Bill { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}

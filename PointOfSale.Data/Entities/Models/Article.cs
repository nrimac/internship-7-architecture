using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Data.Entities.Models
{
    public class Article
    {
        public int Id { get; set; }
        public bool IsSold { get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; }
    }
}

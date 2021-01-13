using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Data.Entities.Models
{
    public class Price
    {
        public int Id { get; set; }
        public int PriceOfOffer { get; set; }

        public ICollection<Offer> Offers { get; set; }
    }
}

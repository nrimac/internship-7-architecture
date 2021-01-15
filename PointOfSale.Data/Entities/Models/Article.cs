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
        public string Name { get; set; }
        public int Count { get; set; }
        public int Cost { get; set; }

        public Offer Offer { get; set; }
    }
}

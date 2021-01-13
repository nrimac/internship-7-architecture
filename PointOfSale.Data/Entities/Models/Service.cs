using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Data.Entities.Models
{
    public class Service
    {
        public int Id { get; set; }
        public int HourlyRates { get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; }

        public Worker Worker { get; set; }
    }
}

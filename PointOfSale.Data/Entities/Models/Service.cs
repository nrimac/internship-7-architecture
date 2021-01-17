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
        public string Name { get; set; }
        public int HourlyRates { get; set; }
        public int NumberOfWorkersNeeded { get; set; }

        public Offer Offer { get; set; }
    }
}

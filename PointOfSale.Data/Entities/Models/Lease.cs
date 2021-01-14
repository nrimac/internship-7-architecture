using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Data.Entities.Models
{
    public class Lease
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DailyRates { get; set; }
        public bool IsActive { get; set; } = false;

        public Offer Offer { get; set; }
    }
}

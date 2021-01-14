using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Data.Entities.Models
{
    public class ServiceBill
    {
        public int Id { get; set; }
        public int Profit { get; set; }

        public Order Order { get; set; }
    }
}

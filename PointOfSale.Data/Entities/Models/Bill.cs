using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Data.Entities.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public int FullCost { get; set; }

        public ICollection<Offer> Offers { get; set; }

        public OneOffBill OneOffBill { get; set; }
        public SubscriptionBill SubscriptionBill { get; set; }
        public ServiceBill ServiceBill { get; set; }
    }
}

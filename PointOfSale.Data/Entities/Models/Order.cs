using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Data.Entities.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int FullProfit { get; set; }

        public ICollection<Offer> Offers { get; set; }

        public ICollection<Worker> Workers { get; set; }

        public int? OneOffBillId { get; set; }
        public virtual OneOffBill OneOffBill { get; set; }

        public int? SubscriptionBillId { get; set; }
        public virtual SubscriptionBill SubscriptionBill { get; set; }

        public int? ServiceBillId { get; set; }
        public virtual ServiceBill ServiceBill { get; set; }
    }
}

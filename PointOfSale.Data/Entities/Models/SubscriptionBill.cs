﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Data.Entities.Models
{
    public class SubscriptionBill
    {
        public int Id { get; set; }
        public string BuyerFirstName { get; set; }
        public string BuyerLastName { get; set; }
        public string BuyerOib { get; set; }
        public int Cost { get; set; }

        public int BillId { get; set; }
        public Bill Bill { get; set; }
    }
}

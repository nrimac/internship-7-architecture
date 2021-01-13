using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Data.Entities.Models
{
    public class OneOffBill
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public DateTime DateOfIssue { get; set; }

        public int BillId { get; set; }
        public Bill Bill { get; set; }
    }
}

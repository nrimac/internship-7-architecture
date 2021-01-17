using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Data.Entities.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Oib { get; set; }
        public int DailyWorkHours { get; set; }
        public bool IsAvailable { get; set; } = true;

        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}

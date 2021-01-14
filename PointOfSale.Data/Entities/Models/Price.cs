using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Data.Entities.Models
{
    public class Price
    {
        public int Id { get; set; }
        public int PriceOfArticle { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}

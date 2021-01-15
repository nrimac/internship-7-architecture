using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Presentation.Abstractions
{
    public interface IAction
    {
        public int MenuIndex { get; set; }
        public string Label { get; set; }
        void Call();
    }
}

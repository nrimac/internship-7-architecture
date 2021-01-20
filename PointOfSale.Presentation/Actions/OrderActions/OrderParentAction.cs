using System;
using System.Collections.Generic;
using PointOfSale.Presentation.Abstractions;

namespace PointOfSale.Presentation.Actions.OrderActions
{
    public class OrderParentAction : BaseParentAction
    {
        public OrderParentAction(IList<IAction> actions) : base(actions)
        {
            Label = "Manage orders";
        }

        public override void Call()
        {
            Console.WriteLine("Order management");
            base.Call();
        }
    }
}
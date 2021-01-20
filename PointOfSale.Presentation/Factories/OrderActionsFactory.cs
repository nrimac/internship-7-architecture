using System.Collections.Generic;
using PointOfSale.Domain.Factories;
using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Actions;
using PointOfSale.Presentation.Actions.OrderActions;

namespace PointOfSale.Presentation.Factories
{
    public static class OrderActionsFactory
    {
        public static OrderParentAction GetCategoryParentAction()
        {
            var orderActions = new List<IAction>
            {
                new OrderAddAction(RepositoryFactory.GetRepository<OrderRepository>()),
                new ExitMenuAction()
            };

            var orderParentAction = new OrderParentAction(orderActions);
            return orderParentAction;
        }
    }
}

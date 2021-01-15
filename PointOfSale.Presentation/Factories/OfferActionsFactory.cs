using System.Collections.Generic;
using PointOfSale.Domain.Factories;
using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Actions;
using PointOfSale.Presentation.Actions.OfferActions;

namespace PointOfSale.Presentation.Factories
{
    public static class OfferActionsFactory
    {
        public static OfferParentAction GetOfferParentAction()
        {
            var customerActions = new List<IAction>
            {
                new OfferAddAction(RepositoryFactory.GetRepository<OfferRepository>()),
                new OfferEditAction(RepositoryFactory.GetRepository<OfferRepository>()),
                new OfferDeleteAction(RepositoryFactory.GetRepository<OfferRepository>()),
                new ExitMenuAction()
            };

            var customerParentAction = new OfferParentAction(customerActions);
            return customerParentAction;
        }
    }
}

using System.Collections.Generic;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Extensions;
using PointOfSale.Presentation.Actions;

namespace PointOfSale.Presentation.Factories
{
    public static class MainMenuFactory
    {
        public static IList<IAction> GetMainMenuActions()
        {
            var actions = new List<IAction>
            {
                OfferActionsFactory.GetOfferParentAction(),

                new ExitMenuAction()
            };

            actions.SetActionIndexes();
            return actions;
        }
    }
}

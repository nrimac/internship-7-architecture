using PointOfSale.Presentation.Factories;
using PointOfSale.Presentation.Extensions;

namespace PointOfSale.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainMenuActions = MainMenuFactory.GetMainMenuActions();
            mainMenuActions.PrintActionsAndCall();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Helpers;
using System.Threading;
using PointOfSale.Data.Entities.Models;

namespace PointOfSale.Presentation.Actions.CategoryActions
{
    public class CategoryEditAction : IAction
    {
        private readonly CategoryRepository _categoryRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Edit Category";

        public CategoryEditAction(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Call()
        {
            Console.Clear();

            Console.WriteLine("1. Edit name\n2. Add offer to category\n3. Remove offer from category");

            while (true)
            {
                var userChoice = ReadHelper.IntegerInput();

                switch (userChoice)
                {
                    case 1:
                        EditName();
                        return;
                    case 2:
                        AddOffer();
                        return;
                    case 3:
                        RemoveOffer();
                        return;
                    default:
                        Console.WriteLine("Not an available action");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        public void EditName()
        {
            var categories = _categoryRepository.GetAll();

            if(categories.Count == 0)
            {
                Console.WriteLine("No categories to edit");
                Thread.Sleep(1000);
                return;
            }

            WriteHelper.PrintCategories(categories);

            Console.WriteLine("Input Id of category to edit:");
            var userChoice = ReadHelper.IntegerInput();

            Console.WriteLine("Input new name:");
            var newName = Console.ReadLine();

            Console.WriteLine(_categoryRepository.Edit(newName, userChoice));
        }

        public void AddOffer()
        {
            var allOffers = _categoryRepository.GetOffers();

            if (allOffers.Count == 0)
            {
                Console.WriteLine("No offers to add");
                Thread.Sleep(1000);
                return;
            }

            var categories = _categoryRepository.GetAll();

            if (categories.Count == 0)
            {
                Console.WriteLine("No categories to edit");
                Thread.Sleep(1000);
                return;
            }

            WriteHelper.PrintCategories(categories);

            Console.WriteLine("Input Id of category to edit:");
            var categoryId = ReadHelper.IntegerInput();

            WriteHelper.PrintOffers(allOffers);

            Console.WriteLine("Input OFFER ID to add the offer to the chosen category:");
            var offerId = ReadHelper.IntegerInput();

            Console.WriteLine(_categoryRepository.AddOffer(categoryId,offerId));
        }

        public void RemoveOffer()
        {
            var categories = _categoryRepository.GetAll();

            if (categories.Count == 0)
            {
                Console.WriteLine("No categories to edit");
                Thread.Sleep(1000);
                return;
            }

            WriteHelper.PrintCategories(categories);

            Console.WriteLine("Input Id of category to edit:");
            var categoryId = ReadHelper.IntegerInput();

            var offersInCategory = _categoryRepository.GetOffersInCategory(categoryId);

            if (offersInCategory == null)
            {
                Console.WriteLine("Category not found");
                Thread.Sleep(1000);
            }
            else
            {
                WriteHelper.PrintOffers(offersInCategory);

                Console.WriteLine("Input offer Id to remove from category:");
                var offerId = ReadHelper.IntegerInput();

                Console.WriteLine(_categoryRepository.RemoveOffer(categoryId, offerId));

                Thread.Sleep(1000);
            }
        }
    }
}

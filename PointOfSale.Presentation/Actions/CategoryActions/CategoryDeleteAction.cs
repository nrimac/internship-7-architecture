using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Helpers;
using System.Threading;

namespace PointOfSale.Presentation.Actions.CategoryActions
{
    public class CategoryDeleteAction : IAction
    {
        private readonly CategoryRepository _categoryRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Delete Category";

        public CategoryDeleteAction(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Call()
        {
            var categories = _categoryRepository.GetAll();
            if(categories.Count == 0)
            {
                Console.WriteLine("No categories to delete");
                Thread.Sleep(1000);
                return;
            }

            WriteHelper.PrintCategories(categories);

            Console.WriteLine("Input Id number of category to delete");
            var userChoice = ReadHelper.IntegerInput();

            Console.WriteLine(_categoryRepository.Delete(userChoice));
        }
    }
}

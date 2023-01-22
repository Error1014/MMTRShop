using MMTRShopWPF.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Commands
{
    public class AddCategoryCommand:MyCommand<CategoryViewModel>
    {
        CategoryService categoryService = new CategoryService();
        public AddCategoryCommand(CategoryViewModel categoryViewModel) : base(categoryViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            string title = viewModel.Category.Title;
            categoryService.Add(title);
            categoryService.Save();
            viewModel.Categories = categoryService.GetCategories();
        }
    }
}

using MMTRShopWPF.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Commands
{
    public class RemoveCategoryCommand: MyCommand<CategoryViewModel>
    {
        CategoryService categoryService = new CategoryService();
        public RemoveCategoryCommand(CategoryViewModel categoryViewModel) : base(categoryViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            CategoryViewModel categoryViewModel = viewModel as CategoryViewModel;
            categoryService.Remove(categoryViewModel.Category);
            categoryService.Save();
            categoryViewModel.Categories = categoryService.GetCategories();
        }
    }
}

using MMTRShopWPF.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Commands
{
    public class SaveCategoryCommand:MyCommand<CategoryViewModel>
{
        CategoryService categoryService = new CategoryService();
        public SaveCategoryCommand(CategoryViewModel categoryViewModel) : base(categoryViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            CategoryViewModel categoryViewModel = viewModel;
            categoryService.SaveChanges(categoryViewModel.Category);
            categoryViewModel.Categories = categoryService.GetCategories();
        }
    }
}

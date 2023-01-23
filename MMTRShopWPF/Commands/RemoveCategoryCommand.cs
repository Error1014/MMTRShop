using MMTRShopWPF.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Commands
{
    public class RemoveCategoryCommand: BaseCommand<CategoryViewModel>
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
            categoryService.Remove(viewModel.Category);
            categoryService.Save();
            viewModel.Categories = categoryService.GetCategories();
        }
    }
}

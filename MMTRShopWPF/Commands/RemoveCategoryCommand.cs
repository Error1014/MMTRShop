using MMTRShop.Model.Models;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Services;
using MMTRShopWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Commands
{
    public class RemoveCategoryCommand: BaseCommand<CategoryViewModel>
    {
        CategoryService categoryService = new CategoryService(new UnitOfWork(new ShopContext()));
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

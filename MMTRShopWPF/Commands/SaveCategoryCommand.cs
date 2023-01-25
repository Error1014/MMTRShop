using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Repositories;
using MMTRShopWPF.Service.Services;
using MMTRShopWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Commands
{
    public class SaveCategoryCommand:BaseCommand<CategoryViewModel>
{
        CategoryService categoryService = new CategoryService(new UnitOfWork(new ShopContext()));
        public SaveCategoryCommand(CategoryViewModel categoryViewModel) : base(categoryViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            categoryService.SaveChanges(viewModel.Category);
            viewModel.Categories = categoryService.GetCategories();
        }
    }
}

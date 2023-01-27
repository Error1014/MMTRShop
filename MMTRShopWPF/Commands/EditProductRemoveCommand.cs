using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Services;
using MMTRShop.Model.Models;
using MMTRShopWPF.View.Pages;
using MMTRShopWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Commands
{
    public class EditProductRemoveCommand:BaseCommand<EditProductViewModel>
    {
        ProductService ProductService = new ProductService(new UnitOfWork(new ShopContext()));
        public EditProductRemoveCommand(EditProductViewModel editProductViewModel) : base(editProductViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            Product product = ProductService.GetProduct(viewModel.Product);
            ProductService.RemoveResultEdit(viewModel.IsAdd, viewModel.Product);
            NavigarionManager.MainFrame.Content = new KatalogPage();
        }
    }
}

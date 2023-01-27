using MMTRShop.Service.Services;
using MMTRShop.Model.Models;
using MMTRShop.Repository.Repositories;
using MMTRShopWPF.View.Pages;
using MMTRShopWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Commands
{
    public class EditProductSaveResultCommand: BaseCommand<EditProductViewModel>
    {
        ProductService ProductService = new ProductService(new UnitOfWork(new ShopContext()));
        public EditProductSaveResultCommand(EditProductViewModel editProductViewModel) : base(editProductViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            Product product = ProductService.GetProduct(viewModel.Product);
            if (viewModel.IsAdd)
            {
                product = new Product();
            }
            product.Title = viewModel.Title;
            product.Price = viewModel.Price;
            product.Discount = viewModel.Discount;
            product.Description = viewModel.Description;
            product.CategoryId = viewModel.SelectCategory.Id;
            product.BrandId = viewModel.SelectBrand.Id;
            product.CountInStarage = viewModel.CountInStorage;
            ProductService.SeveResultEdit(viewModel.IsAdd, product);
            NavigarionManager.MainFrame.Content = new KatalogPage();
        }
    }
}

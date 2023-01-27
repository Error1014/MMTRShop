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
    public class LoadedKatalogVMCommand : BaseCommand<KatalogViewModel>
    {
        private ProductService ProductService = new ProductService(new UnitOfWork(new ShopContext()));
        public LoadedKatalogVMCommand(KatalogViewModel katalogViewModel) : base(katalogViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
           viewModel.ProductsPage = ProductService.GetPageProducts(viewModel.NumPage, viewModel.SizePage);
        }
    }
}

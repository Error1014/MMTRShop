using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using MMTRShopWPF.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Commands
{
    public class EditProductSaveResultCommand: MyCommand<EditProductViewModel>
    {
        ProductService ProductService = new ProductService();
        public EditProductSaveResultCommand(EditProductViewModel editProductViewModel) : base(editProductViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            ProductService.SeveResultEdit(viewModel.IsAdd, viewModel.Product);
            NavigarionManager.MainFrame.Content = new KatalogPage();
        }
    }
}

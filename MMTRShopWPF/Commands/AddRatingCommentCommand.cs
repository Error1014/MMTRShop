using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using MMTRShopWPF.View.Pages;
using MMTRShopWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MMTRShopWPF.Commands
{
    public class AddRatingCommentCommand:BaseCommand<MyHistoryViewModel>
    {
        public AddRatingCommentCommand(MyHistoryViewModel myHistoryViewModel) : base(myHistoryViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            viewModel.VisibilityPanelFeedback = true;
            viewModel.ProductId = Guid.Parse(parameter.ToString());
        }
        
    }
}

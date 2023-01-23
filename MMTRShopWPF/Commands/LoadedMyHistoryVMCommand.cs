using MMTRShopWPF.Service.Services;
using MMTRShopWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Commands
{
    public class LoadedMyHistoryVMCommand:BaseCommand<MyHistoryViewModel>
    {
        private OrderContentService OrderContentService = new OrderContentService();
        public LoadedMyHistoryVMCommand(MyHistoryViewModel myHistoryViewModel) : base(myHistoryViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            viewModel.OrderContents = OrderContentService.GetCancelledOrder();
        }
    }
}

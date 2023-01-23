using MMTRShopWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MMTRShopWPF.Commands
{
    public class SelectRatingCommand : BaseCommand<MyHistoryViewModel>
    {
        public SelectRatingCommand(MyHistoryViewModel myHistoryViewModel) : base(myHistoryViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            viewModel.Rating = Convert.ToByte(parameter.ToString());
        }
    }
}

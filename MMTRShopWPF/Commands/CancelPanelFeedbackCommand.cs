using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Commands
{
    public class CancelPanelFeedbackCommand:BaseCommand<MyHistoryViewModel>
    {
        public CancelPanelFeedbackCommand(MyHistoryViewModel myHistoryViewModel) : base(myHistoryViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            viewModel.VisibilityPanelFeedback = false;
        }
    }
}

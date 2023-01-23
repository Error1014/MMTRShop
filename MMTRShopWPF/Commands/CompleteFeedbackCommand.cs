using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using MMTRShopWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Commands
{
    public class CompleteFeedbackCommand : BaseCommand<MyHistoryViewModel>
    {
        private FeedbackService FeedbackService = new FeedbackService();
        public CompleteFeedbackCommand(MyHistoryViewModel myHistoryViewModel) : base(myHistoryViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            viewModel.VisibilityPanelFeedback = false;
            Feedback feedback = new Feedback();
            if (String.IsNullOrEmpty(viewModel.Comment) || String.IsNullOrWhiteSpace(viewModel.Comment))
            {
                feedback = new Feedback(AccountManager.Client.Id, viewModel.ProductId, viewModel.Rating, null);
            }
            else
            {
                feedback = new Feedback(AccountManager.Client.Id, viewModel.ProductId, viewModel.Rating, viewModel.Comment);
            }
            FeedbackService.AddFeedback(feedback);
            FeedbackService.SaveFeedback();
        }
    }
}

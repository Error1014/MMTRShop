using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using MMTRShopWPF.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MMTRShopWPF.ViewModels
{
    public class MyHistoryViewModel : BaseViewModel
    {
        private OrderContentService OrderContentService = new OrderContentService();
        private FeedbackService FeedbackService = new FeedbackService();
        public MyHistoryViewModel()
        {
            OrderContents = OrderContentService.GetCancelledOrder();
        }
        private List<OrderContent> orderContents;
        public List<OrderContent> OrderContents
        {
            get { return orderContents; }
            set
            {
                orderContents = value;
                OnPropertyChanged(nameof(OrderContents));
            }
        }
        private Guid productId;
        private byte rating;
        private string comment;
        public string Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }
        private bool visibilityPanelFeedback = false;
        public bool VisibilityPanelFeedback
        {
            get { return visibilityPanelFeedback; }
            set
            {
                visibilityPanelFeedback = value;
                OnPropertyChanged(nameof(VisibilityPanelFeedback));
            }
        }
        public ICommand AddRatingComment
        {
            get
            {
                return new Commands((obj) =>
                {
                    VisibilityPanelFeedback = true;
                    productId = Guid.Parse(obj.ToString());
                });
            }
        }


        public ICommand SelectRating
        {
            get
            {
                return new Commands((obj) =>
                {
                    rating =Convert.ToByte(obj.ToString());
                });
            }
        }
        public ICommand Cancel
        {
            get
            {
                return new Commands((obj) =>
                {
                    VisibilityPanelFeedback = false;
                });
            }
        }
        public ICommand CompleteFeedback
        {
            get
            {
                return new Commands((obj) =>
                {
                    VisibilityPanelFeedback = false;
                    Feedback feedback = new Feedback();
                    if (String.IsNullOrEmpty(Comment)||String.IsNullOrWhiteSpace(Comment))
                    {
                        feedback = new Feedback(AccountManager.Client.Id, productId, rating, null);
                    }
                    else
                    {
                        feedback = new Feedback(AccountManager.Client.Id, productId, rating, comment);
                    }
                    FeedbackService.AddFeedback(feedback);
                    FeedbackService.SaveFeedback();
                });
            }
        }

    }
}

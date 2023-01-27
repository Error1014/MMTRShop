using MMTRShopWPF.Commands;
using MMTRShop.Model.Models;
using MMTRShop.Service.Services;
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
        public Guid ProductId
        {
            get { return productId; }
            set
            {
                productId = value;
                OnPropertyChanged(nameof(ProductId));
            }
        }
        private byte rating;
        public byte Rating
        {
            get { return rating; }
            set
            {
                rating = value;
                OnPropertyChanged(nameof(Rating));
            }
        }
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
        private ICommand getOrderContentsСompleted;
        public ICommand GetOrderContentsСompleted
        {
            get
            {
                if (getOrderContentsСompleted == null) getOrderContentsСompleted = new LoadedMyHistoryVMCommand(this);
                return getOrderContentsСompleted;
            }
        }
        private ICommand addRatingComment;
        public ICommand AddRatingComment
        {
            get
            {
                if (addRatingComment == null) addRatingComment = new AddRatingCommentCommand(this);
                return addRatingComment;
            }
        }


        private ICommand selectRating;
        public ICommand SelectRating
        {
            get
            {
                if (selectRating == null) selectRating = new SelectRatingCommand(this);
                return selectRating;
            }
        }
        private ICommand cancel;
        public ICommand Cancel
        {
            get
            {
                if (cancel == null) cancel = new CancelPanelFeedbackCommand(this);
                return cancel;
            }
        }
        private ICommand completeFeedback;
        public ICommand CompleteFeedback
        {
            get
            {
                if (completeFeedback == null) completeFeedback = new CompleteFeedbackCommand(this);
                return completeFeedback;
            }
        }

    }
}

using MMTRShopWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service
{
    public class BankCardViewModel:BaseViewModel
    {
        public BankCardViewModel()
        {

        }

        private BankCard bankCard;
        public BankCard BankCard
        {
            get { return bankCard; }
            set 
            { 
                bankCard = value;
                OnPropertyChanged(nameof(BankCard));
            }
        }

    }
}

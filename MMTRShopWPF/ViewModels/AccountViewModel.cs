using MMTRShop.Model.Models;
using MMTRShopWPF.Commands;
using MMTRShop.Service.Services;
using MMTRShopWPF.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace MMTRShopWPF.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        #region User
        private User user;
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                LastName = value.LastName;
                FirstName = value.FirstName;
                Patronymic = value.Patronymic;
                OnPropertyChanged(nameof(User));
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        private string patronymic;
        public string Patronymic
        {
            get { return patronymic; }
            set
            {
                patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }
        #endregion
        #region Client
        private Client client;
        public Client Client
        {
            get { return client; }
            set
            {
                client = value;
                Email = value.Email;
                Phone = value.Phone;
                Address = value.Address;
                OnPropertyChanged(nameof(Client));
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        #endregion


        private ICommand loadedAcountVM;
        public ICommand LoadedAcountVM
        {
            get
            {
                if (loadedAcountVM == null) loadedAcountVM = new LoadedAccountVMCommand(this);
                return loadedAcountVM;
            }
        }

        private bool visibilityEditButton = true;
        public bool VisibilityEditButton
        {
            get { return visibilityEditButton; }
            set
            {
                visibilityEditButton = value;
                OnPropertyChanged(nameof(VisibilityEditButton));
            }
        }
        private bool visibilitySaveAndCancelButton;
        public bool VisibilitySaveAndCancelButton
        {
            get { return visibilitySaveAndCancelButton; }
            set
            {
                visibilitySaveAndCancelButton = value;
                OnPropertyChanged(nameof(VisibilitySaveAndCancelButton));
            }
        }

        private ICommand edit;
        public ICommand Edit
        {
            get
            {
                if (edit==null) edit = new ClickEditCommand(this);
                return edit;
            }
        }
        private ICommand cancel;
        public ICommand Cancel
        {
            get
            {
                if (cancel == null) cancel = new CancelEditCommand(this);
                return cancel;
            }
        }
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null) save = new SaveAccountSettingsCommand(this);
                return save;
            }
        }
    }
}

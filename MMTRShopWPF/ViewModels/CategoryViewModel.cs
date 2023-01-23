using MMTRShopWPF.Commands;
using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MMTRShopWPF.ViewModels
{
    public class CategoryViewModel:BaseViewModel
    {
        private ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }


        private Category category = new Category();
        public Category Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
        private ICommand getCategories;
        public ICommand GetCategories
        {
            get
            {
                if (getCategories == null) getCategories = new LoadedCategoriesVMCommand(this);
                return getCategories;
            }
        }
        private ICommand add;
        public ICommand AddCategory
        {
            get
            {
                if (add == null) add = new AddCategoryCommand(this);
                return add;
            }
        }
        private ICommand remove;
        public ICommand RemoveCategory
        {
            get
            {
                if (remove == null) remove = new RemoveCategoryCommand(this);
                return remove;
            }
        }
        private ICommand save;
        public ICommand SaveChanged
        {
            get
            {
                if (save == null) save = new SaveCategoryCommand(this);
                return save;
            }
        }

        private bool visibilityBtnAdminRemoveAdd;
        public bool VisibilityBtnAdminRemoveAdd
        {
            get 
            {
                if (visibilityBtnAdminRemoveAdd == false)
                {
                    if (AccountManager.Operator==null)
                    {
                        VisibilityBtnAdminRemoveAdd = true;
                    }
                }
                return visibilityBtnAdminRemoveAdd; 
            }
            set
            {
                visibilityBtnAdminRemoveAdd = value;
                OnPropertyChanged(nameof(VisibilityBtnAdminRemoveAdd));
            }
        }
    }
}

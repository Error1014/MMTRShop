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

namespace MMTRShopWPF.Commands
{
    public class CategoryViewModel:BaseViewModel
    {
        private CategoryService CategoryService = new CategoryService();
        public CategoryViewModel()
        {
            Categories = CategoryService.GetCategories();
            if (AccountManager.Admin == null)
            {
                VisibilityBtnAdminRemoveAdd = false;
            }
            else
            {
                visibilityBtnAdminRemoveAdd = true;
            }
            saveResult = new CategoryCreationCommand(SaveResult.Save);
            addCategory = new CategoryCreationCommand(AddCategory.Add);
            removeCategory = new CategoryCreationCommand(RemoveCategory.Remove);
        }

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
        private CategoryCreationCommand saveResult = new CategoryCreationCommand(null);
        public CategoryCreationCommand SaveResult
        {
            get 
            {
                return saveResult;
            }
        }
        private CategoryCreationCommand addCategory = new CategoryCreationCommand(null);
        public CategoryCreationCommand AddCategory
        {
            get
            {
                return addCategory;
            }
        }
        private CategoryCreationCommand removeCategory = new CategoryCreationCommand(null);
        public CategoryCreationCommand RemoveCategory
        {
            get 
            {
                return removeCategory;
            }
        }
        
        private bool visibilityBtnAdminRemoveAdd;
        public bool VisibilityBtnAdminRemoveAdd
        {
            get { return visibilityBtnAdminRemoveAdd; }
            set
            {
                visibilityBtnAdminRemoveAdd = value;
                OnPropertyChanged(nameof(VisibilityBtnAdminRemoveAdd));
            }
        }
    }
}

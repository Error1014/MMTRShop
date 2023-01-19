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
        private bool isCreate = false;
        private CategoryService CategoryService = new CategoryService();
        public CategoryViewModel()
        {
            Categories = CategoryService.GetCategories();
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

        public ICommand SaveCategory
        {
            get
            {
                return new Commands((obj) =>
                {
                    
                    if (isCreate)
                    {
                        CategoryService.Create(Category);
                        isCreate=false;
                        CategoryService.Save();
                        Category = new Category();
                    }
                    CategoryService.Save();
                    Categories = CategoryService.GetCategories();
                });
            }
        }
        public ICommand CreateCategory
        {
            get
            {
                return new Commands((obj) =>
                {
                    Category = new Category() ;
                    isCreate = true;
                });
            }
        }
        public ICommand RemoveCategory
        {
            get
            {
                return new Commands((obj) =>
                {
                    Message = CategoryService.CheckToRemove(Category);
                    if (!Message.IsError())
                    {
                        CategoryService.Remove(Category);
                        Categories = CategoryService.GetCategories();
                        Category = new Category();
                    }
                });
            }
        }
    }
}

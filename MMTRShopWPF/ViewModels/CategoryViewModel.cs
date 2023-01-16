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
        public CategoryViewModel()
        {
            Categories = CategoryService.GetCategory();
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
                    CategoryService.Save();
                    Category = new Category();
                    Categories = CategoryService.GetCategory();
                });
            }
        }
        public ICommand CreateCategory
        {
            get
            {
                return new Commands((obj) =>
                {
                    string titleCategory = Category.Title;
                    Category = new Category();
                    CategoryService.Create(titleCategory);
                    Categories = CategoryService.GetCategory();
                });
            }
        }
        public ICommand RemoveCategory
        {
            get
            {
                return new Commands((obj) =>
                {
                    CategoryService.Remove(Category);
                    Categories = CategoryService.GetCategory();
                    Category = new Category();
                });
            }
        }
    }
}

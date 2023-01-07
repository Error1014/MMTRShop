using MMTRShopWPF.Service;
using MMTRShopWPF.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MMTRShopWPF.ViewModel
{
    public class ProductVievModel : BaseViewModel
    {
        private bool isAdd;
        public ProductVievModel(Product product)
        {
            if (product == null)
            {
                isAdd = true;
                selectCategory = AllCategory.First();
                Product = new Product();
            }
            else
            {
                isAdd = false;
                selectCategory = ShopContext.GetContext().Category.Where(category => category.ID == product.CategoryID).First();
                Product = product;
            }

        }

        private User user = NavigationViewModel.User;


        private Product product;

        public Product Product
        {
            get
            {
                return product;
            }
            set
            {
                product = value;
                OnPropertyChanged(nameof(Product));
            }
        }
        public ICommand AddInKorzine
        {
            get
            {
                return new Commands((obj) =>
                {
                    if (user == null)
                    {
                        MessageBox.Show("Для этого вам сперва необходимо войти в аккаутн");
                        MainWindow.MainWindowFrame.Content = new AutorizationPage();
                    }
                    else
                    {
                        var myKorzine = ShopContext.GetContext().Korzine.Where(korzine => korzine.UserID == user.ID).ToList();
                        bool isNew = true;
                        for (int i = 0; i < myKorzine.Count; i++)
                        {
                            if (myKorzine[i].ProductID == Product.ID)
                            {
                                isNew = false;
                                myKorzine[i].ValueProduct++;
                            }
                        }
                        if (isNew)
                        {
                            ShopContext.GetContext().Korzine.Add(new Korzine(user.ID, Product.ID, 1));
                        }
                        ShopContext.GetContext().SaveChanges();
                        MessageBox.Show("Успешно");
                    }
                });
            }
        }

        public ICommand SaveResult
        {
            get
            {
                return new Commands((obj) =>
                {
                    product.CategoryID = SelectCategory.ID;
                    if (isAdd)
                    {
                        ShopContext.GetContext().Product.Add(product);
                        isAdd = false;
                    }
                    ShopContext.GetContext().SaveChanges();
                    MessageBox.Show("Успешно");
                });
            }
        }
        public ICommand Delete
        {
            get
            {
                return new Commands((obj) =>
                {
                    if (!isAdd)
                    {
                        ShopContext.GetContext().Product.Remove(product);
                        isAdd = true;
                    }
                    ShopContext.GetContext().SaveChanges();
                    MessageBox.Show("Успешно");
                });
            }
        }
        public List<Category> AllCategory { get; private set; } = ShopContext.GetContext().Category.ToList();
        private Category selectCategory;
        public Category SelectCategory
        {
            get { return selectCategory; }
            set
            {
                selectCategory = value;
                OnPropertyChanged(nameof(Category));
            }
        }
    }
}

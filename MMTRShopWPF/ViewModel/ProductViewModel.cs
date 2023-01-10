using MMTRShopWPF.Repositoryes;
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
            AllCategory = UnitOfWork.Categorys.GetAll().ToList();
            AllBrand = UnitOfWork.Brands.GetAll().ToList();
            if (product == null)
            {
                isAdd = true;
                SelectCategory = AllCategory.First();
                SelectBrand = AllBrand.First();
                Product = new Product();
            }
            else
            {
                isAdd = false;
                SelectCategory = AllCategory.Where(category => category.Id == product.CategoryId).First();
                SelectBrand = AllBrand.Where(brand => brand.ID == product.BrandId).First();
                Product = UnitOfWork.Products.GetById(product.Id);
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
                        var myKorzine = UnitOfWork.Korzins.GetKorzineByIDUser(user.ID);
                        bool isNew = true;
                        for (int i = 0; i < myKorzine.Count; i++)
                        {
                            if (myKorzine[i].ProductId == Product.Id)
                            {
                                isNew = false;
                                myKorzine[i].ProductCount++;
                            }
                        }
                        if (isNew)
                        {
                            UnitOfWork.Korzins.Add(new Cart(user.ID, Product.Id, 1));
                        }
                        UnitOfWork.Korzins.Save();
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
                    product.CategoryId = SelectCategory.Id;
                    product.BrandId = SelectBrand.ID;
                    if (isAdd)
                    {
                        UnitOfWork.Products.Add(Product);
                        isAdd = false;
                    }
                    UnitOfWork.Products.Save();
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
                        UnitOfWork.Products.Remove(Product);
                        isAdd = true;
                    }
                    UnitOfWork.Products.Save();
                    MessageBox.Show("Успешно");
                });
            }
        }
        public List<Category> AllCategory { get; private set; }
        private Category selectCategory;
        public Category SelectCategory
        {
            get { return selectCategory; }
            set
            {
                selectCategory = value;
                OnPropertyChanged(nameof(SelectCategory));
            }
        }

        public List<Brand> AllBrand { get; private set; }
        private Brand selectBrand;
        public Brand SelectBrand
        {
            get { return selectBrand; }
            set
            {
                selectBrand = value;
                OnPropertyChanged(nameof(SelectBrand));
            }
        }
    }
}

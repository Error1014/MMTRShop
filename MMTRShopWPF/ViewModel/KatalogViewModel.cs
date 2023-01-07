using MMTRShopWPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MMTRShopWPF.ViewModel
{
    public class KatalogViewModel : BaseViewModel
    {
        private int valuePage = 0;
        private int numPage = 1;
        public int NumPage
        {
            get { return numPage; }
            set
            {
                numPage = value;
                OnPropertyChanged(nameof(numPage));
            }
        }
        public int Num1 { get; private set; } = 1;
        public int Num2 { get; private set; } = 2;
        public int Num3 { get; private set; } = 3;
        public int Num4 { get; private set; } = 4;
        public int Num5 { get; private set; } = 5;


        private int SizePage = 20;
        public KatalogViewModel()
        {
            productsPage = GetPageProduct();
            if (ShopContext.GetContext().Product.Count() % SizePage == 0)
            {
                valuePage = ShopContext.GetContext().Product.Count() / SizePage;
            }
            else
            {
                valuePage = ShopContext.GetContext().Product.Count() / SizePage + 1;
            }

        }

        public List<Product> GetPageProduct()
        {
            return ShopContext.GetContext().Product.OrderBy(product => product.ID).Skip((numPage - 1) * SizePage).Take(SizePage).ToList();
        }

        private List<Product> productsPage;
        public List<Product> ProductsPage
        {
            get
            {
                return productsPage;
            }
            set
            {
                productsPage = value;
                OnPropertyChanged(nameof(ProductsPage));
            }
        }

        public ICommand PagePlus
        {
            get
            {
                return new Commands((obj) =>
                {
                    if (NumPage < valuePage)
                    {
                        NumPage++;
                        SetNumPage(1);
                    }

                    ProductsPage = GetPageProduct();
                });
            }
        }
        public ICommand PageMinus
        {
            get
            {
                return new Commands((obj) =>
                {
                    if (NumPage > 1)
                    {
                        NumPage--;
                        SetNumPage(-1);
                    }
                    ProductsPage = GetPageProduct();
                });
            }
        }

        public void SetNumPage(int value)
        {
            Num1 += value;
            Num2 += value;
            Num3 += value;
            Num4 += value;
            Num5 += value;
            OnPropertyChanged(nameof(Num1));
            OnPropertyChanged(nameof(Num2));
            OnPropertyChanged(nameof(Num3));
            OnPropertyChanged(nameof(Num4));
            OnPropertyChanged(nameof(Num5));
        }
    }
}

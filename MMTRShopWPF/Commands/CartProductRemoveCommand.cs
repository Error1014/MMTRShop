using MMTRShopWPF.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Commands
{
    public class CartProductRemoveCommand:BaseCommand<CartViewModel>
    {
        private CartService CartService = new CartService();
        public CartProductRemoveCommand(CartViewModel cartViewModel) : base(cartViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            Guid id = Guid.Parse(parameter.ToString());
            CartService.CartRemoveProduct(id);
            viewModel.Cart = CartService.GetCart();
        }
    }
}

using MMTRShop.Service.Services;

namespace MMTRShopAPI.Middleware.Exceptions
{
    public class NotFoundException: Exception
{
        public NotFoundException(string message) : base(message)
        {
            
        }
    }
}

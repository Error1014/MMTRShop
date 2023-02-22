using Microsoft.AspNetCore.Mvc;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
{
    public interface IProductService
    {
        Task<ProductDTO> GetProduct(Guid id);

        Task AddProduct(ProductDTO product);
        Task RemoveProduct(Guid productId);
        Task Update(ProductDTO product);
        Task Save();

        Task<IEnumerable<ProductDTO>> GetPageProducts(ProductPageFilter filter);

    }
}

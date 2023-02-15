using Microsoft.AspNetCore.Mvc;
using MMTRShop.DTO.DTO;
using MMTRShop.Model.HelperModels;
using MMTRShop.Model.Models;
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

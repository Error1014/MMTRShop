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

        void AddProduct(ProductDTO product);
        Task RemoveProduct(ProductDTO product);
        void Update(ProductDTO product);
        void Save();

        Task<IEnumerable<ProductDTO>> GetPageProducts(ProductPageFilter filter);

    }
}

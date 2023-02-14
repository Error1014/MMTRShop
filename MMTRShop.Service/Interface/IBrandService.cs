﻿using MMTRShop.DTO.DTO;
using MMTRShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDTO>> GetBrands();
        Task<BrandDTO> GetBrand(Guid brandId);
        void AddBrand(BrandDTO brand);
        Task RemoveBrand(Guid brand);
        Task Update(BrandDTO brand);
        Task Save();
    }
}

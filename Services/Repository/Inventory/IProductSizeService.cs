﻿using Pms.Models.Entity.Settings;

namespace Pms.Data.Repository.Inventory
{
    public interface IProductSizeService
    {
        Task<bool> Delete(long ProductSizeId);
        
       
        Task<IEnumerable<ProductSze>> Get(long? ProductSizeId, string? ProductSizeKey, long? LanguageId, string? ProductSizeName, int? PageNumber, int? PageSize);
        Task<ProductSze> GetById(long ProductSizeId);
      
        Task<ProductSze> GetByKey(string ProductSizeKey);
       
       
        Task<long> SaveOrUpdate(ProductSze _ProductSize);
    }
}
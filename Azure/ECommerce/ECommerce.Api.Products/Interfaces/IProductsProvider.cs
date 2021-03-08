using ECommerce.Api.Products.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product = ECommerce.Api.Products.Models.Product;

namespace ECommerce.Api.Products.Interfaces
{
    interface IProductsProvider
    {
        Task<(bool IsSuccess, IEnumerable<Models.Product> Products, string ErrorMessage)>
            GetProductsAsync();
    }
}

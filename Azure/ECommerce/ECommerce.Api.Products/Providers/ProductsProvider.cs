using ECommerce.Api.Products.Db;
using ECommerce.Api.Products.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace ECommerce.Api.Products.Providers
{
    public class ProductsProvider : IProductsProvider
    {
        private readonly ProductsDbContext _dbContext;
        private readonly ILogger<ProductsProvider> _logger;
        private readonly IMapper _mapper;

        public ProductsProvider(ProductsDbContext dbContext, ILogger<ProductsProvider> logger, IMapper mapper)
        {
            this._dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!_dbContext.Products.Any())
            {
                _dbContext.Products.Add(new Db.Product() {Id = 1, Name = "Keyboard", Price = 20, Inventory = 100});
                _dbContext.Products.Add(new Db.Product() {Id = 2, Name = "Mouse", Price = 5, Inventory = 100});
                _dbContext.Products.Add(new Db.Product() {Id = 3, Name = "Monitor", Price = 150, Inventory = 100});
                _dbContext.Products.Add(new Db.Product() {Id = 4, Name = "CPU", Price = 200, Inventory = 200});
                _dbContext.SaveChanges();
            }
        }

        public Task<(bool IsSuccess, IEnumerable<Models.Product> Products, string ErrorMessage)> GetProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}

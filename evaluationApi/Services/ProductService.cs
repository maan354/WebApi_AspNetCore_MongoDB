using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using evaluationApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace evaluationApi.Services
{
    public class ProductService : IProductsService
    {
        private readonly ProductContext _context = null;

        public ProductService(IOptions<Settings> settings)
        {
            _context = new ProductContext(settings);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                return await _context.Product.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Product> GetProduct(string id)
        {
            var filter = Builders<Product>.Filter.Eq("_id", id);

            try
            {
                return await _context.Product
                                .Find(filter)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddProduct(Product product)
        {
            try
            {
                await _context.Product.InsertOneAsync(product);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Product> UpdateProduct(string id, Product product)
        {
            try
            {
                await _context.Product
                                    .ReplaceOneAsync(c => c._id.Equals(id)
                                            , product
                                            , new UpdateOptions { IsUpsert = true });

                Product productResult = await GetProduct(id);

                return productResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteProduct(string id)
        {
            try
            {
                DeleteResult actionResult = await _context.Product.DeleteOneAsync(
                        Builders<Product>.Filter.Eq("_id", id));

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

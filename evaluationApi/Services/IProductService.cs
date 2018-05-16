using System.Collections.Generic;
using System.Threading.Tasks;
using evaluationApi.Models;

namespace evaluationApi.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProduct(string id);
        Task<bool> AddProduct(Product product);
        Task<Product> UpdateProduct(string id, Product product);
        Task<bool> DeleteProduct(string id);
    }
}

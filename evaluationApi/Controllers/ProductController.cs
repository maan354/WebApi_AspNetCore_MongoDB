
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using evaluationApi.Services;
using evaluationApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace evaluationApi.Controllers
{
    [Route("api/produto")]
    public class ProductController : Controller
    {
        private readonly IProductsService _productService;

        public ProductController(IProductsService productService)
        {
            _productService = productService;
        }

        // GET: notes/notes
        [HttpGet]
        public Task<IEnumerable<Product>> Get()
        {
            return GetProductInternal();
        }

        private async Task<IEnumerable<Product>> GetProductInternal()
        {
            IEnumerable<Product> categoriesResult = await _productService.GetAllProducts();
            return categoriesResult;
        }

        // GET api/notes/5
        [HttpGet("{id}")]
        public Task<Product> Get(string id)
        {
            return GetNoteByIdInternal(id);
        }

        private async Task<Product> GetNoteByIdInternal(string id)
        {
            var productResult = await _productService.GetProduct(id) ?? new Product();
            return productResult;
        }

        // POST api/notes
        [HttpPost]
        public async Task<bool> Post([FromBody]Product product)
        {
            return await _productService.AddProduct(product);
        }

        // PUT api/notes/5
        [HttpPut("{id}")]
        public async Task<Product> Put(string id, [FromBody]Product product)
        {
            Product productResult = await _productService.UpdateProduct(id, product);
            return productResult;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            return await DeleteInternal(id);
        }

        // DELETE api/notes/5
        public Task<bool> DeleteInternal(string id)
        {
            return _productService.DeleteProduct(id);
        }
    }
}

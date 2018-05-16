using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using evaluationApi.Services;
using Newtonsoft.Json;
using evaluationApi.Models;

namespace evaluationApi.Controllers
{
    [Route("api/categoria")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: notes/notes
        [HttpGet]
        public Task<IEnumerable<Category>> Get()
        {
            return GetCategoryInternal();
        }

        private async Task<IEnumerable<Category>> GetCategoryInternal()
        {
            IEnumerable<Category> categoriesResult = await _categoryService.GetAllCategories();
            return categoriesResult;
        }

        // GET api/notes/5
        [HttpGet("{id}")]
        public Task<Category> Get(string id)
        {
            return GetNoteByIdInternal(id);
        }

        private async Task<Category> GetNoteByIdInternal(string id)
        {
            var categoryResult = await _categoryService.GetCategory(id) ?? new Category();
            return categoryResult;
        }

        // POST api/notes
        [HttpPost]
        public async Task<bool> Post([FromBody]Category category)
        {
            return await _categoryService.AddCategory(category);
        }

        // PUT api/notes/5
        [HttpPut("{id}")]
        public async Task<Category> Put(string id, [FromBody]Category category)
        {
            Category categoryResult = await _categoryService.UpdateCategory(id, category);
            return categoryResult;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            return await DeleteInternal(id);
        }

        // DELETE api/notes/5
        public Task<bool> DeleteInternal(string id)
        {
            return _categoryService.DeleteCategory(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using evaluationApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace evaluationApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryContext _context = null;

        public CategoryService(IOptions<Settings> settings)
        {
            _context = new CategoryContext(settings);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            try
            {
                return await _context.Category.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Category> GetCategory(string id)
        {
            var filter = Builders<Category>.Filter.Eq("_id", id);

            try
            {
                return await _context.Category
                                .Find(filter)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddCategory(Category category)
        {
            try
            {
                await _context.Category.InsertOneAsync(category);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Category> UpdateCategory(string id, Category category)
        {
            try
            {
                await _context.Category
                                    .ReplaceOneAsync(c => c._id.Equals(id)
                                            , category
                                            , new UpdateOptions { IsUpsert = true });

                Category categoryResult = await GetCategory(id);

                return categoryResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteCategory(string id)
        {
            try
            {
                DeleteResult actionResult = await _context.Category.DeleteOneAsync(
                        Builders<Category>.Filter.Eq("_id", id));

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

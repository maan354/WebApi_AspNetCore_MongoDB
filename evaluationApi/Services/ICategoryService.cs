using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using evaluationApi.Models;

namespace evaluationApi.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategory(string id);
        Task<bool> AddCategory(Category category);
        Task<Category> UpdateCategory(string id, Category category);
        Task<bool> DeleteCategory(string id);
    }
}

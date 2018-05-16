using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using evaluationApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace evaluationApi
{
    public class CategoryContext
    {
        private readonly IMongoDatabase _database = null;
        
        public CategoryContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if(client != null)
                _database = client.GetDatabase(settings.Value.DatabaseName);            
        }

        public IMongoCollection<Category> Category
        {
            get
            {
                return _database.GetCollection<Category>("Category");
            }
        }
    }
}

using evaluationApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace evaluationApi
{
    public class ProductContext
    {
        private readonly IMongoDatabase _database = null;

        public ProductContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Product> Product
        {
            get
            {
                return _database.GetCollection<Product>("Product");
            }
        }
    }
}

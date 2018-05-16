using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace evaluationApi.Models
{
    public class Product
    {
        [Required]
        [BsonRequired]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string _id { get; set; }

        [Required]
        [BsonRequired]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [BsonRequired]
        public decimal Price { get; set; } = 0;

        [Required]
        [BsonRequired]
        public bool Status { get; set; } = true;

        [Required]
        [BsonRequired]
        public Category Category { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}

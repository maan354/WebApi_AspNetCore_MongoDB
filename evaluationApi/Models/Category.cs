using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace evaluationApi.Models
{
    public class Category
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
        public bool Status { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}

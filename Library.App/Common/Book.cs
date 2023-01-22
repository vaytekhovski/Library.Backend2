using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Library.App.Common
{
    [BsonIgnoreExtraElements]
    public class Book
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("imageUri")]
        public string ImageURI { get; set; } = string.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;
        [BsonElement("creationDate")]
        public DateTime? CreationDate { get; set; }
        [BsonElement("authorsId")]
        public string[]? AuthorsId { get; set; }
    }
}


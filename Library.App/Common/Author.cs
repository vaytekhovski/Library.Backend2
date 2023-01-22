using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Library.App.Common
{
    [BsonIgnoreExtraElements]
	public class Author
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("imageUri")]
        public string ImageURI { get; set; } = string.Empty;
        [BsonElement("fullName")]
		public string FullName { get; set; } = string.Empty;
        [BsonElement("biography")]
        public string Biography { get; set; } = string.Empty;
        [BsonElement("dateOfBirth")]
        public DateTime? DateOfBirth { get; set; }
        [BsonElement("dateOfDeath")]
        public DateTime? DateOfDeath { get; set; }
        //[BsonElement("books")]
        //public Book[]? Books { get; set; }
    }
}


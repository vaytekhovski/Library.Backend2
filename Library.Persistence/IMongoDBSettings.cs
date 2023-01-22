using System;
namespace Library.Persistence
{
	public interface IMongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string AuthorsCollectionName { get; set; }
        public string BooksCollectionName { get; set; }

    }
}


﻿using System;
using Library.App.Interfaces;

namespace Library.App
{
	public class MongoDBSettings : IMongoDBSettings
	{
		public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string AuthorsCollectionName { get; set; } = string.Empty;
        public string BooksCollectionName { get; set; } = string.Empty;
    }
}


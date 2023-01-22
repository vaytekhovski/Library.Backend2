using System;
using Library.App.Common;
using MongoDB.Bson;

namespace Library.App.Interfaces
{
	public interface IMongoDBService
	{
            Task CreateAuthorAsync(Author author);

            Task<List<Author>> GetAuthorsAsync();

            Task<Author> GetAuthorAsync(string id);

            Task DeleteAuthorAsync(string id);

            Task UpdateAuthorAsync(string authorId, Author author);

            Task CreateBookAsync(Book book);

            Task<Book> GetBookAsync(string id);

            Task<List<Book>> GetBooksByAuthorAsync(string authorId);

            Task<List<Book>> GetBooksAsync();

            Task DeleteBookAsync(string id);

            Task UpdateBookAsync(string bookId, Book book);
    }
}


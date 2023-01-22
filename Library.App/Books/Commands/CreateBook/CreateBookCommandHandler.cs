using System;
using Library.App.Authors.Commands.CreateAuthor;
using Library.App.Common;
using Library.App.Interfaces;
using MediatR;
using MongoDB.Driver;

namespace Library.App.Books.Commands.CreateBook
{
	public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, string?>
    {
        public IMongoCollection<Book> _books { get; set; }

        public CreateBookCommandHandler(IMongoDBSettings settings, IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(settings.DatabaseName);
            _books = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        public async Task<string?> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book()
            {
                ImageURI = request.ImageURI,
                Name = request.Name,
                Description = request.Description,
                CreationDate = request.CreationDate,
                AuthorsId = request.AuthorsId
            };

            await _books.InsertOneAsync(book);

            return book.Id;
        }
    }
}


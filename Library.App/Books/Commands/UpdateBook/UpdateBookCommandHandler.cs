using System;
using System.Net;
using Library.App.Authors.Commands.UpdateAuthor;
using Library.App.Common;
using Library.App.Common.Exceptions;
using Library.App.Interfaces;
using MediatR;
using MongoDB.Driver;

namespace Library.App.Books.Commands.UpdateBook
{
	public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        public IMongoCollection<Book> _books { get; set; }

        public UpdateBookCommandHandler(IMongoDBSettings settings, IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(settings.DatabaseName);
            _books = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _books.Find(b => b.Id == request.Id).FirstOrDefaultAsync();

            if (book == null || book.Id != request.Id)
            {
                throw new NotFoundException(nameof(book), request.Id);
            }

            book.Description = request.Description;
            book.CreationDate = request.CreationDate;
            book.AuthorsId = request.AuthorsId;
            await _books.ReplaceOneAsync(b => b.Id == request.Id, book);

            return Unit.Value;
        }
    }
}


using System;
using Library.App.Authors.Commands.DeleteAuthor;
using Library.App.Common;
using Library.App.Common.Exceptions;
using Library.App.Interfaces;
using MediatR;
using MongoDB.Driver;

namespace Library.App.Books.Commands.DeleteBook
{
	public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        public IMongoCollection<Book> _books { get; set; }

        public DeleteBookCommandHandler(IMongoDBSettings settings, IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(settings.DatabaseName);
            _books = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _books.Find(b => b.Id == request.Id).FirstOrDefaultAsync();

            if (book == null || book.Id != request.Id)
            {
                throw new NotFoundException(nameof(book), request.Id);
            }

            await _books.DeleteOneAsync(b => b.Id == request.Id);
            return Unit.Value;
        }
    }
}


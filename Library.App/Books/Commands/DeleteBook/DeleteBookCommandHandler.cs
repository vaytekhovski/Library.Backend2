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
        private readonly IMongoDBService _dbService;

        public DeleteBookCommandHandler(IMongoDBService dbContext) => _dbService = dbContext;

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _dbService.GetBookAsync(request.Id);

            if (book == null || book.Id != request.Id)
            {
                throw new NotFoundException(nameof(book), request.Id);
            }

            await _dbService.DeleteBookAsync(book.Id);
            return Unit.Value;
        }
    }
}


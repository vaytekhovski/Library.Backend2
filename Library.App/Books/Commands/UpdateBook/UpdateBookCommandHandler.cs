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
        private readonly IMongoDBService _dbService;

        public UpdateBookCommandHandler(IMongoDBService dbContext) => _dbService = dbContext;


        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _dbService.GetBookAsync(request.Id);

            if (book == null || book.Id != request.Id)
            {
                throw new NotFoundException(nameof(book), request.Id);
            }

            book.Description = request.Description;
            book.CreationDate = request.CreationDate;
            book.AuthorsId = request.AuthorsId;
            await _dbService.UpdateBookAsync(book.Id, book);

            return Unit.Value;
        }
    }
}


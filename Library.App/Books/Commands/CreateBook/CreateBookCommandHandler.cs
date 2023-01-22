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
        private readonly IMongoDBService _dbService;

        public CreateBookCommandHandler(IMongoDBService dbContext) => _dbService = dbContext;

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

            await _dbService.CreateBookAsync(book);

            return book.Id;
        }
    }
}


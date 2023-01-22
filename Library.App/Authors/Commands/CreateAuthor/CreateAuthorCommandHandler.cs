using System;
using Library.App.Interfaces;
using Library.App.Common;
using MediatR;
using MongoDB.Bson;

namespace Library.App.Authors.Commands.CreateAuthor
{
	public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, string?>
	{
        private readonly IMongoDBService _dbService;

        public CreateAuthorCommandHandler(IMongoDBService dbContext) => _dbService = dbContext;

        public async Task<string?> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
         {
            var author = new Author()
            {
                ImageURI = request.ImageURI,
                FullName = request.FullName,
                Biography = request.Biography,
                DateOfBirth = request.DateOfBirth,
                DateOfDeath = request.DateOfDeath
            };

            await _dbService.CreateAuthorAsync(author);

            return author.Id;
        }
    }
}


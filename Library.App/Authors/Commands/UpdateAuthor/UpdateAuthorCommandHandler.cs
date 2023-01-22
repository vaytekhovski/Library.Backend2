using System;
using Library.App.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Library.App.Common.Exceptions;
using Library.App.Common;
using MongoDB.Driver;

namespace Library.App.Authors.Commands.UpdateAuthor
{
	public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
	{
        private readonly IMongoDBService _dbService;

        public UpdateAuthorCommandHandler(IMongoDBService dbContext) => _dbService = dbContext;


        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _dbService.GetAuthorAsync(request.Id);

            if (author == null || author.Id != request.Id)
            {
                throw new NotFoundException(nameof(author), request.Id);
            }

            author.Biography = request.Biography;
            author.DateOfDeath = request.DateOfDeath;
            await _dbService.UpdateAuthorAsync(author.Id, author);

            return Unit.Value;
        }
    }
}


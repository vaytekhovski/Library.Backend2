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
        public IMongoCollection<Author> _authors { get; set; }

        public UpdateAuthorCommandHandler(IMongoDBSettings settings, IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(settings.DatabaseName);
            _authors = database.GetCollection<Author>(settings.AuthorsCollectionName);
        }

        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _authors.Find(a => a.Id == request.Id).FirstOrDefaultAsync();

            if (author == null || author.Id != request.Id)
            {
                throw new NotFoundException(nameof(author), request.Id);
            }

            author.Biography = request.Biography;
            author.DateOfDeath = request.DateOfDeath;
            await _authors.ReplaceOneAsync(a => a.Id == request.Id, author);

            return Unit.Value;
        }
    }
}


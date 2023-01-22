using System;
using Library.App.Common;
using Library.App.Common.Exceptions;
using Library.App.Interfaces;
using MediatR;
using MongoDB.Driver;

namespace Library.App.Authors.Commands.DeleteAuthor
{
	public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
	{
        public IMongoCollection<Author> _authors { get; set; }

        public DeleteAuthorCommandHandler(IMongoDBSettings settings, IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(settings.DatabaseName);
            _authors = database.GetCollection<Author>(settings.AuthorsCollectionName);
        }

        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _authors.Find(a => a.Id == request.Id).FirstOrDefaultAsync();

            if (author == null || author.Id != request.Id)
            {
                throw new NotFoundException(nameof(author), request.Id);
            }

            await _authors.DeleteOneAsync(a => a.Id == request.Id);
            return Unit.Value;
        }
    }
}


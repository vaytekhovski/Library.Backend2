using System;
using Library.App.Interfaces;
using Library.App.Common;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Library.App.Authors.Commands.CreateAuthor
{
	public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, string?>
	{
        public IMongoCollection<Author> _authors { get; set; }

        public CreateAuthorCommandHandler(IMongoDBSettings settings, IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(settings.DatabaseName);
            _authors = database.GetCollection<Author>(settings.AuthorsCollectionName);
        }

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

            await _authors.InsertOneAsync(author);

            return author.Id;
        }
    }
}


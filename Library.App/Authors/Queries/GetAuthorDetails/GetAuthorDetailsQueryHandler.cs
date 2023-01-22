using System;
using AutoMapper;
using Library.App.Common;
using Library.App.Common.Exceptions;
using Library.App.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Library.App.Authors.Queries.GetAuthorDetails
{
	public class GetAuthorDetailsQueryHandler : IRequestHandler<GetAuthorDetailsQuery,AuthorDetailVm>
	{
        private readonly IMapper _mapper;
        public IMongoCollection<Author> _authors { get; set; }

        public GetAuthorDetailsQueryHandler(IMongoDBSettings settings, IMongoClient mongoClient, IMapper mapper)
        {
            IMongoDatabase database = mongoClient.GetDatabase(settings.DatabaseName);
            _authors = database.GetCollection<Author>(settings.AuthorsCollectionName);
            _mapper = mapper;
        }

        public async Task<AuthorDetailVm> Handle(GetAuthorDetailsQuery request, CancellationToken cancellationToken)
        {
            var author = await _authors.Find(a => a.Id == request.Id).FirstOrDefaultAsync();

            if (author == null || author.Id != request.Id)
            {
                throw new NotFoundException(nameof(author), request.Id);
            }

            return _mapper.Map<AuthorDetailVm>(author);
        }
    }
}


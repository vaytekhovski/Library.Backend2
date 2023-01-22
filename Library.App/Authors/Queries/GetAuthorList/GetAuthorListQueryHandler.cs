using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.App.Authors.Queries.GetAuthorDetails;
using Library.App.Common;
using Library.App.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Library.App.Authors.Queries.GetAuthorList
{
    public class GetAuthorListQueryHandler : IRequestHandler<GetAuthorListQuery, List<AuthorDetailVm>>
    {
        private readonly IMapper _mapper;
        public IMongoCollection<Author> _authors { get; set; }

        public GetAuthorListQueryHandler(IMongoDBSettings settings, IMongoClient mongoClient, IMapper mapper)
        {
            IMongoDatabase database = mongoClient.GetDatabase(settings.DatabaseName);
            _authors = database.GetCollection<Author>(settings.AuthorsCollectionName);
            _mapper = mapper;
        }

        public async Task<List<AuthorDetailVm>> Handle(GetAuthorListQuery request, CancellationToken cancellationToken)
        {
            var result = await _authors.Find(new BsonDocument()).ToListAsync();
            return result.Select(a => _mapper.Map<AuthorDetailVm>(a)).ToList();

        }
    }
}


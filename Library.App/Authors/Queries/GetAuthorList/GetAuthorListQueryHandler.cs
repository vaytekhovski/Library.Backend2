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
        private readonly IMongoDBService _dbService;

        public GetAuthorListQueryHandler(IMongoDBService dbContext, IMapper mapper) => (_dbService, _mapper) = (dbContext, mapper);


        public async Task<List<AuthorDetailVm>> Handle(GetAuthorListQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbService.GetAuthorsAsync();
            return result.Select(a => _mapper.Map<AuthorDetailVm>(a)).ToList();

        }
    }
}


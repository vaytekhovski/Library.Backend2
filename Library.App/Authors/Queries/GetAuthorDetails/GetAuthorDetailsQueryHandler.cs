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
        private readonly IMongoDBService _dbService;

        public GetAuthorDetailsQueryHandler(IMongoDBService dbContext, IMapper mapper) => (_dbService, _mapper) = (dbContext, mapper);


        public async Task<AuthorDetailVm> Handle(GetAuthorDetailsQuery request, CancellationToken cancellationToken)
        {
            var author = await _dbService.GetAuthorAsync(request.Id);

            if (author == null || author.Id != request.Id)
            {
                throw new NotFoundException(nameof(author), request.Id);
            }

            return _mapper.Map<AuthorDetailVm>(author);
        }
    }
}


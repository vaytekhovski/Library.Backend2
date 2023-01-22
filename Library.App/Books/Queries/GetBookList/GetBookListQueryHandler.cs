using System;
using AutoMapper;
using Library.App.Authors.Queries.GetAuthorDetails;
using Library.App.Authors.Queries.GetAuthorList;
using Library.App.Books.Queries.GetBookDetails;
using Library.App.Common;
using Library.App.Interfaces;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Library.App.Books.Queries.GetBookList
{
	public class GetBookListQueryHandler : IRequestHandler<GetBookListQuery, List<BookDetailVm>>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDBService _dbService;

        public GetBookListQueryHandler(IMongoDBService dbContext, IMapper mapper) => (_dbService, _mapper) = (dbContext, mapper);


        public async Task<List<BookDetailVm>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            var result = request.Id != null
                ? await _dbService.GetBooksByAuthorAsync(request.Id)
                : await _dbService.GetBooksAsync();

            return result.Select(a => _mapper.Map<BookDetailVm>(a)).ToList();

        }
    }
}


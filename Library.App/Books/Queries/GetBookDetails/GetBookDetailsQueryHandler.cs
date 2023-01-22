using System;
using AutoMapper;
using Library.App.Authors.Queries.GetAuthorDetails;
using Library.App.Common;
using Library.App.Common.Exceptions;
using Library.App.Interfaces;
using MediatR;
using MongoDB.Driver;

namespace Library.App.Books.Queries.GetBookDetails
{
	public class GetBookDetailsQueryHandler : IRequestHandler<GetBookDetailsQuery, BookDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDBService _dbService;

        public GetBookDetailsQueryHandler(IMongoDBService dbContext, IMapper mapper) => (_dbService, _mapper) = (dbContext, mapper);

        public async Task<BookDetailVm> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
        {
            var book = await _dbService.GetBookAsync(request.Id);

            if (book == null || book.Id != request.Id)
            {
                throw new NotFoundException(nameof(book), request.Id);
            }

            return _mapper.Map<BookDetailVm>(book);
        }
    }
}


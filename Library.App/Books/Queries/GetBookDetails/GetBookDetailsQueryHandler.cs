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
        public IMongoCollection<Book> _books { get; set; }

        public GetBookDetailsQueryHandler(IMongoDBSettings settings, IMongoClient mongoClient, IMapper mapper)
        {
            IMongoDatabase database = mongoClient.GetDatabase(settings.DatabaseName);
            _books = database.GetCollection<Book>(settings.BooksCollectionName);
            _mapper = mapper;
        }

        public async Task<BookDetailVm> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
        {
            var book = await _books.Find(b => b.Id == request.Id).FirstOrDefaultAsync();

            if (book == null || book.Id != request.Id)
            {
                throw new NotFoundException(nameof(book), request.Id);
            }

            return _mapper.Map<BookDetailVm>(book);
        }
    }
}


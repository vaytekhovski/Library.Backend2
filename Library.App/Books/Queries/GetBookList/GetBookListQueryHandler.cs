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
        public IMongoCollection<Book> _books { get; set; }

        public GetBookListQueryHandler(IMongoDBSettings settings, IMongoClient mongoClient, IMapper mapper)
        {
            IMongoDatabase database = mongoClient.GetDatabase(settings.DatabaseName);
            _books = database.GetCollection<Book>(settings.BooksCollectionName);
            _mapper = mapper;
        }

        public async Task<List<BookDetailVm>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            var result = request.Id != null
                ? await _books.Find(Book => Book.AuthorsId.Contains(request.Id)).ToListAsync()
                : await _books.Find(new BsonDocument()).ToListAsync();

            return result.Select(a => _mapper.Map<BookDetailVm>(a)).ToList();

        }
    }
}


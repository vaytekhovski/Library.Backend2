using System;
using Library.App.Authors.Queries.GetAuthorDetails;
using Library.App.Books.Queries.GetBookDetails;
using MediatR;

namespace Library.App.Books.Queries.GetBookList
{
	public class GetBookListQuery : IRequest<List<BookDetailVm>>
    {
        public string? Id { get; set; } = string.Empty;
    }
}


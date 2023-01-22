using System;
using Library.App.Authors.Queries.GetAuthorDetails;
using MediatR;

namespace Library.App.Books.Queries.GetBookDetails
{
	public class GetBookDetailsQuery : IRequest<BookDetailVm>
    {
        public string Id { get; set; } = string.Empty;
    }
}


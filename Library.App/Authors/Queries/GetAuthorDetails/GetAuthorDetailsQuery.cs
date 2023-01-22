
using System;
using MediatR;
using MongoDB.Bson;

namespace Library.App.Authors.Queries.GetAuthorDetails
{
	public class GetAuthorDetailsQuery : IRequest<AuthorDetailVm>
	{
		public string Id { get; set; } = string.Empty;
	}
}


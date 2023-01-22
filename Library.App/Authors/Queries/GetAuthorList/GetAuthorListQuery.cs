using System;
using Library.App.Authors.Queries.GetAuthorDetails;
using MediatR;

namespace Library.App.Authors.Queries.GetAuthorList
{
	public class GetAuthorListQuery : IRequest<List<AuthorDetailVm>>
	{
	}
}


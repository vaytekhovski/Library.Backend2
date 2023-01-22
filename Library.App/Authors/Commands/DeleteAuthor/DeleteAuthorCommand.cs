using System;
using MediatR;
using MongoDB.Bson;

namespace Library.App.Authors.Commands.DeleteAuthor
{
	public class DeleteAuthorCommand : IRequest
	{
		public string Id { get; set; } = string.Empty;
	}
}


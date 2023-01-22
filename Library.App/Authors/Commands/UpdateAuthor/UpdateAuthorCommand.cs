using System;
using MongoDB.Bson;
using MediatR;

namespace Library.App.Authors.Commands.UpdateAuthor
{
	public class UpdateAuthorCommand : IRequest
	{
		public string Id { get; set; } = string.Empty;
		public string Biography { get; set; } = string.Empty;
		public DateTime? DateOfDeath { get; set; }
	}
}


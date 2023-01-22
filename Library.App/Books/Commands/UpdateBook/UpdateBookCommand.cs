using System;
using MediatR;

namespace Library.App.Books.Commands.UpdateBook
{
	public class UpdateBookCommand : IRequest
    {
        public string Id { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? CreationDate { get; set; }
        public string[]? AuthorsId { get; set; } = null;
    }
}


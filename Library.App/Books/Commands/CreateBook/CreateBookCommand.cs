using System;
using MediatR;

namespace Library.App.Books.Commands.CreateBook
{
	public class CreateBookCommand : IRequest<string?>
    {
        public string ImageURI { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? CreationDate { get; set; } = null;
        public string[]? AuthorsId { get; set; } = null;
    }
}


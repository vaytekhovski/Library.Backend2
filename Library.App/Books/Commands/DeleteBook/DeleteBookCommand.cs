using System;
using MediatR;

namespace Library.App.Books.Commands.DeleteBook
{
	public class DeleteBookCommand : IRequest
    {
        public string Id { get; set; } = string.Empty;
    }
}


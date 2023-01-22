using System;
using FluentValidation;
using Library.App.Authors.Commands.DeleteAuthor;

namespace Library.App.Books.Commands.DeleteBook
{
	public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}


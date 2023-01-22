using System;
using FluentValidation;
using Library.App.Authors.Commands.CreateAuthor;

namespace Library.App.Books.Commands.CreateBook
{
	public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Name).NotEmpty().MaximumLength(250);
            RuleFor(command => command.ImageURI).NotEmpty();
        }
    }
}


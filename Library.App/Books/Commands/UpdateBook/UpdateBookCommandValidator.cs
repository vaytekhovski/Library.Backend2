using System;
using FluentValidation;
using Library.App.Authors.Commands.UpdateAuthor;

namespace Library.App.Books.Commands.UpdateBook
{
	public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.Description).NotEmpty();
        }
    }
}


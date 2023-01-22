using System;
using FluentValidation;

namespace Library.App.Authors.Commands.UpdateAuthor
{
	public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
	{
		public UpdateAuthorCommandValidator()
		{
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.Biography).NotEmpty();
        }
    }
}


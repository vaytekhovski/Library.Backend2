using System;
using FluentValidation;

namespace Library.App.Authors.Commands.DeleteAuthor
{
	public class UpdateAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
	{
		public UpdateAuthorCommandValidator()
		{
			RuleFor(command => command.Id).NotEmpty();
		}
	}
}


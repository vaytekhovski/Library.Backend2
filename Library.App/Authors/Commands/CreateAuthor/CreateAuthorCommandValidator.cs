using System;
using FluentValidation;

namespace Library.App.Authors.Commands.CreateAuthor
{
	public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
	{
		public CreateAuthorCommandValidator()
		{
			RuleFor(command => command.FullName).NotEmpty().MaximumLength(250);
			RuleFor(command => command.ImageURI).NotEmpty();
		}
	}
}


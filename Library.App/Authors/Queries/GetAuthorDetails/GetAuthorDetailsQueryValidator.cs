using System;
using FluentValidation;

namespace Library.App.Authors.Queries.GetAuthorDetails
{
	public class GetAuthorDetailsQueryValidator : AbstractValidator<GetAuthorDetailsQuery>
	{
		public GetAuthorDetailsQueryValidator()
		{
			RuleFor(command => command.Id).NotEmpty();
		}
	}
}


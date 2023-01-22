using System;
using FluentValidation;
using Library.App.Authors.Queries.GetAuthorDetails;

namespace Library.App.Books.Queries.GetBookDetails
{
	public class GetBookDetailsQueryValidator : AbstractValidator<GetBookDetailsQuery>
    {
        public GetBookDetailsQueryValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}


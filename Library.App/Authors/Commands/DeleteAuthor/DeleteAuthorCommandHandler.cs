using System;
using Library.App.Common.Exceptions;
using Library.App.Interfaces;
using MediatR;

namespace Library.App.Authors.Commands.DeleteAuthor
{
	public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
	{
        private readonly IMongoDBService _dbService;

        public DeleteAuthorCommandHandler(IMongoDBService dbService) => _dbService = dbService;

        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _dbService.GetAuthorAsync(request.Id);

            if(author == null || author.Id != request.Id)
            {
                throw new NotFoundException(nameof(author), request.Id);
            }

            await _dbService.DeleteAuthorAsync(author.Id);
            return Unit.Value;
        }
    }
}


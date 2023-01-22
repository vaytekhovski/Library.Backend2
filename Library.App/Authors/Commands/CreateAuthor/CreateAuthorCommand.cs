using MediatR;
using MongoDB.Bson;

namespace Library.App.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<string?>
	{
        public string ImageURI { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
		public string Biography { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; } = null;
        public DateTime? DateOfDeath { get; set; } = null;
    }
}


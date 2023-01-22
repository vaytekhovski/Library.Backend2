using System;
using AutoMapper;
using MongoDB.Bson;
using Library.App.Common.Mapping;
using Library.App.Common;

namespace Library.App.Authors.Queries.GetAuthorDetails
{
	public class AuthorDetailVm : IMapWith<Author>
	{
		public string Id { get; set; } = string.Empty;
        public string ImageURI { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
		public string Biography { get; set; } = string.Empty;
		public DateTime? DateOfBirth { get; set; }
		public DateTime? DateOfDeath { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Author, AuthorDetailVm>()
				.ForMember(vm => vm.Id, opt => opt.MapFrom(author => author.Id))
                .ForMember(vm => vm.ImageURI, opt => opt.MapFrom(author => author.ImageURI))
                .ForMember(vm => vm.FullName, opt => opt.MapFrom(author => author.FullName))
				.ForMember(vm => vm.Biography, opt => opt.MapFrom(author => author.Biography))
				.ForMember(vm => vm.DateOfBirth, opt => opt.MapFrom(author => author.DateOfBirth))
				.ForMember(vm => vm.DateOfDeath, opt => opt.MapFrom(author => author.DateOfDeath));

        }
	}
}


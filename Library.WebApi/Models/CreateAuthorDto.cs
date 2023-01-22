using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Library.App.Authors.Commands.CreateAuthor;
using Library.App.Common.Mapping;

namespace Library.WebApi.Models
{
	public class CreateAuthorDto : IMapWith<CreateAuthorDto>
	{
		public string ImageURI { get; set; } = string.Empty;
		public string FullName { get; set; } = string.Empty;
		public string Biography { get; set; } = string.Empty;
		public DateTime? DateOfBirth { get; set; } = null;
		public DateTime? DateOfDeath { get; set; } = null;

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateAuthorDto, CreateAuthorCommand>()
				.ForMember(a => a.ImageURI, opt => opt.MapFrom(aDto => aDto.ImageURI))
                .ForMember(a => a.FullName, opt => opt.MapFrom(aDto => aDto.FullName))
                .ForMember(a => a.Biography, opt => opt.MapFrom(aDto => aDto.Biography))
				.ForMember(a => a.DateOfBirth, opt => opt.MapFrom(aDto => aDto.DateOfBirth))
				.ForMember(a => a.DateOfDeath, opt => opt.MapFrom(aDto => aDto.DateOfDeath));

        }
	}
}


using System;
using AutoMapper;
using Library.App.Books.Commands.CreateBook;
using Library.App.Common.Mapping;

namespace Library.WebApi.Models
{
	public class CreateBookDto : IMapWith<CreateBookDto>
    {
        public string ImageURI { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? CreationDate { get; set; } = null;
        public string[]? AuthorsId { get; set; } = null;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBookDto, CreateBookCommand>()
                .ForMember(a => a.ImageURI, opt => opt.MapFrom(aDto => aDto.ImageURI))
                .ForMember(a => a.Name, opt => opt.MapFrom(aDto => aDto.Name))
                .ForMember(a => a.Description, opt => opt.MapFrom(aDto => aDto.Description))
                .ForMember(a => a.CreationDate, opt => opt.MapFrom(aDto => aDto.CreationDate))
                .ForMember(a => a.AuthorsId, opt => opt.MapFrom(aDto => aDto.AuthorsId));


        }
    }
}


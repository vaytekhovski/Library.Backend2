using System;
using AutoMapper;
using Library.App.Books.Commands.UpdateBook;
using Library.App.Common.Mapping;

namespace Library.WebApi.Models
{
	public class UpdateBookDto : IMapWith<UpdateBookDto>
    {
        public string Id { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateBookDto, UpdateBookCommand>()
                .ForMember(a => a.Id, opt => opt.MapFrom(aDto => aDto.Id))
                .ForMember(a => a.Description, opt => opt.MapFrom(aDto => aDto.Description))
                .ForMember(a => a.CreationDate, opt => opt.MapFrom(aDto => aDto.CreationDate));

        }
    }
}


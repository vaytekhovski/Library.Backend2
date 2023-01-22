using System;
using AutoMapper;
using Library.App.Authors.Queries.GetAuthorDetails;
using Library.App.Common;
using Library.App.Common.Mapping;

namespace Library.App.Books.Queries.GetBookDetails
{
	public class BookDetailVm : IMapWith<Book>
    {
        public string Id { get; set; } = string.Empty;
        public string ImageURI { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookDetailVm>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(author => author.Id))
                .ForMember(vm => vm.ImageURI, opt => opt.MapFrom(author => author.ImageURI))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(author => author.Name))
                .ForMember(vm => vm.Description, opt => opt.MapFrom(author => author.Description))
                .ForMember(vm => vm.CreationDate, opt => opt.MapFrom(author => author.CreationDate));

        }
    }
}


using AutoMapper;
using LibraryAPI.Entities;
using LibraryAPI.Models;

namespace LibraryAPI
{
    public class LibraryMappingProfile : Profile
    {
        public LibraryMappingProfile() 
        {
            CreateMap<Book, BookDto>()
                .ForMember(m => m.AuthorName, c => c.MapFrom(s => s.Author.Name));

            CreateMap<Category, CategoryDto>();
            CreateMap<CreateBookDto, Book>()
                .ForMember(m => m.Author,
                    c => c.MapFrom(dto => new Author() 
                    { Name = dto.AuthorName }));

            CreateMap<CategoryDto, Category>();
        }
    }
}

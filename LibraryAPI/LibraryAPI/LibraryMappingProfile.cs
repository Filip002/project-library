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
        }
    }
}

using AutoMapper;
using LibraryAPI.Entities;
using LibraryAPI.Exceptions;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public interface IBookService
    {
        BookDto GetById(int id);
    }

    public class BookService : IBookService
    {
        private readonly LibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public BookService(LibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookDto GetById(int id)
        {
            var book = _dbContext
                .Books
                .Include(b => b.Author)
                .Include(b => b.Categories)
                .FirstOrDefault(b => b.Id == id);

            if (book is null)
                throw new NotFoundException("Book not found");

            var result = _mapper.Map<BookDto>(book);
            return result;
        }
    }
}

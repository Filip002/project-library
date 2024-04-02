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
        IEnumerable<BookDto> GetAll(BookQuery query);
        int Create(CreateBookDto dto);
        void DeleteById(int id);
        void Update(int id, UpdateBookDto dto);
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

        public int Create(CreateBookDto dto)
        {
            var book = _mapper.Map<Book>(dto);

            _dbContext.Add(book);
            _dbContext.SaveChanges();

            return book.Id;
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

        public IEnumerable<BookDto> GetAll(BookQuery query)
        {
            var books = _dbContext
                .Books
                .Include(b => b.Author)
                .Include(b => b.Categories)
                .Where(b => query.SearchPhrase == null || b.Title.ToLower().Contains(query.SearchPhrase.ToLower())
                    || b.Description.ToLower().Contains(query.SearchPhrase.ToLower()));

            var booksDtos = _mapper.Map<List<BookDto>>(books);
            return booksDtos;
        }

        public void DeleteById(int id)
        {
            var book = _dbContext
                .Books
                .FirstOrDefault(b => b.Id == id);

            if (book is null)
                throw new NotFoundException("Book not found");

            _dbContext.Remove(book);
            _dbContext.SaveChanges();
        }

        public void Update(int id, UpdateBookDto dto)
        {
            var book = _dbContext
                .Books
                .FirstOrDefault(b => b.Id == id);

            if (book is null)
                throw new NotFoundException("Book not found");

            book.Title = dto.Title;
            book.Description = dto.Description;
            book.IsAvailable = dto.IsAvailable;

            _dbContext.SaveChanges();
        }
    }
}

using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public ActionResult<BookDto> Get([FromRoute] int id)
        {
            var book = _bookService.GetById(id);

            return Ok(book);
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetAll()
        {
            var books = _bookService.GetAll();

            return Ok(books);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateBook([FromBody]CreateBookDto dto)
        {
            var id = _bookService.Create(dto);

            return Created($"/api/book/{id}", null);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            _bookService.DeleteById(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Update([FromRoute]int id, [FromBody]UpdateBookDto dto)
        {
            _bookService.Update(id, dto);

            return Ok();
        }
    }
}

using LibraryAPI.Entities;

namespace LibraryAPI.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public bool IsAvailable { get; set; }
        public string AuthorName { get; set; }

        public List<Category> Categories { get; set; }
    }
}

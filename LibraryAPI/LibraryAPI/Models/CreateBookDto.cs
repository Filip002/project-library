using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class CreateBookDto
    {
        [Required]
        [MinLength(3)]
        public string Title { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public bool IsAvailable { get; set; }
        [Required]
        public string AuthorName { get; set; }

        public List<CategoryDto> Categories { get; set; }
    }
}

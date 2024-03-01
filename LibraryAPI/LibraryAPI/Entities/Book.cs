namespace LibraryAPI.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public bool IsAvailable { get; set; }
        public int? CheckedOutById { get; set; }
        public int AuthorId { get; set; }

        public virtual User CheckedOutBy { get; set; }
        public virtual Author Author { get; set; }

        public virtual List<Category> Categories { get; set; }
    }
}

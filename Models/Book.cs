namespace BookManagementSystem.Models
{
    public class Book {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PublishedYear { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }
    }
}

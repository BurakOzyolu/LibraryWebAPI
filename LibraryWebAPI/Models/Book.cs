namespace LibraryWebAPI.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int AuthorId { get; set; }
        public int TypeId { get; set; }
        public int Year { get; set; }
    }
}

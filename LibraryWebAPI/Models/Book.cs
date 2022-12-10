namespace LibraryWebAPI.Models
{
    public class Book:BaseModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int NumberOfPages { get; set; }
        public int WriterId { get; set; }
        public int TypeId { get; set; }
        public int CreatedYear { get; set; }
    }
}

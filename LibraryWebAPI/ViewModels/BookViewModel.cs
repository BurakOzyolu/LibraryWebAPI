namespace LibraryWebAPI.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Writer { get; set; }
        public string Type { get; set; }
        public int CreatedYear { get; set; }
        public int NumberOfPages { get; set; }
    }
}

using LibraryWebAPI.Models;

namespace LibraryWebAPI.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Writer { get; set; } = "Yazar Tanımlanmamış";
        public int? WriterId { get; set; }
        public string Type { get; set; } = "Tipi tanımlanmamış";
        public int? TypeId { get; set; }
        public int? CreatedYear { get; set; }
        public int? NumberOfPages { get; set; }
        public string BookImage { get; set; }
        public BookType BookType { get; set; }
        public Writer WriterC { get; set; }


    }
}

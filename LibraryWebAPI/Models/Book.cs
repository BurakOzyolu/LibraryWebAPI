using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.Models
{
    public class Book:BaseModel
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int NumberOfPages { get; set; }
        public int WriterId { get; set; }
        public Writer Writer { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
        public int CreatedYear { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.Models
{
    public class Writer:BaseModel
    {
        [Key]
        public int WriterId { get; set; }
        public string WriterName { get; set; }
        public ICollection<Book> Books { get; set; }

    }
}

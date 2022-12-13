using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.Models
{
    public class Type:BaseModel
    {
        [Key]
        public int typeId { get; set; }
        public string typeName { get; set; }
        public ICollection<Book> Books { get; set; }

    }
}

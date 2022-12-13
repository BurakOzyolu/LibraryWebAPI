using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.Models
{
    public class Process 
    {
        [Key]
        public int ProcessId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}

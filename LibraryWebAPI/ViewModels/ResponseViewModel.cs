using LibraryWebAPI.Models;
using System.Collections.Generic;

namespace LibraryWebAPI.ViewModels
{
    public class ResponseViewModel
    {
        public int  StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<User> Users { get; set; }
        public List<Book> listBook { get; set; }
        public List<Student> Students { get; set; }
        public List<Grade> Grades { get; set; }
        public List<Type> Types { get; set; }
        public List<Writer> Writers { get; set; }

    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public ICollection<Student> Student { get; set; }

    }
}

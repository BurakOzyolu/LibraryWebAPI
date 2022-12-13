using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.Models
{
    public class Student:BaseModel
    {
        [Key]
        public int studentId { get; set; }
        public string studentName { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
        public string UserId { get; set; }
    }
}

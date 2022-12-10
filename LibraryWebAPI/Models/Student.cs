namespace LibraryWebAPI.Models
{
    public class Student:BaseModel
    {
        public int studentId { get; set; }
        public string studentName { get; set; }
        public string studentClass { get; set; }
    }
}

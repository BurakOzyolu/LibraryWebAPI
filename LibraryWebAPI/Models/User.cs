using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhonoNo { get; set; }
        public string Role { get; set; }
        public bool? IsDeleted { get; set; }

    }
}

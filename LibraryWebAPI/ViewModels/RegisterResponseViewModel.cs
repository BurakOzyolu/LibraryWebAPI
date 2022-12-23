namespace LibraryWebAPI.ViewModels
{
    public class RegisterResponseViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNo { get; set; }
        public string Role { get; set; }
        public bool IsDeleted { get; set; }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

    }
}

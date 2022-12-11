using LibraryWebAPI.Models;
using LibraryWebAPI.Models.Identites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebAPI
{
   
     public class MyContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
    



}

﻿using LibraryWebAPI.Models;
using LibraryWebAPI.Models.Identites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebAPI
{
   
     public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Writer> Writes { get; set; }
    }


}

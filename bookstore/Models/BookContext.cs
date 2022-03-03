using System;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<Donation> Donations { get; set; }
    }
}

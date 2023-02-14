using System;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; } 
        public DbSet<Disc> Discs { get; set; }
        public DbSet<CD> CDs { get; set; }
        public DbSet<DVD> DVDs { get; set; }
        public DbSet<LibraryInventory> Inventories { get; set; }
    }
}


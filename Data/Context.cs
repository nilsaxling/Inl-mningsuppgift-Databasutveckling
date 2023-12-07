using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inlämningsuppgift_Databasutveckling.Models;
using Microsoft.EntityFrameworkCore;

namespace Inlämningsuppgift_Databasutveckling.Data
{
    internal class Context : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Author> Authors { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Book>()
        //        .HasKey(b => b.Id);

        //    modelBuilder.Entity<Author>()
        //        .HasKey(a => a.Id);

        //    modelBuilder.Entity<Customer>()
        //        .HasKey(c => c.Id);

        //    modelBuilder.Entity<Book>()
        //        .HasOne(b => b.Author)
        //        .WithMany(a => a.Books)
        //        .HasForeignKey(b => b.AuthorId);

        //    modelBuilder.Entity<Book>()
        //        .HasOne(b => b.Customer)
        //        .WithMany(c => c.BooksBorrowed)
        //        .HasForeignKey(b => b.CustomerId);

        //    base.OnModelCreating(modelBuilder);
        //}



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
                Server=localhost;
                Database=NewtonLibrary Nils;
                Trusted_Connection=True;
                Trust Server Certificate=Yes;
                User Id=NewtonLibrary;
                password=NewtonLibrary");
        }
    }
}

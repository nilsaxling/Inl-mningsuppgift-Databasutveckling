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
        public DbSet<Library> Libraries { get; set; }
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

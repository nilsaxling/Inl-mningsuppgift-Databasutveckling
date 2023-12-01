using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inlämningsuppgift_Databasutveckling.Models;

namespace Inlämningsuppgift_Databasutveckling.Data
{
    internal class DataAccess
    {
        public void Seed()
        {
            Context context = new Context();
            Book book1 = new Book();  
            book1.BookTitle = "Jag är Zlatan Ibrahimović";
            book1.Author = "David Lagercrantz";
            book1.Isbn = 987654321;
            book1.ReleaseDate = 11-07-16;
            book1.Rating = 9;
            book1.IsRented = true;
            book1.DateOfLoan = 15-05-23;
            book1.DateOfReturn = 30-07-23;


            Book book2 = new Book();
            book2.BookTitle = "Börje Salming ";
            book2.Author = "Ola Liljedahl";
            book2.Isbn = 678645312;
            book2.ReleaseDate = 21-02-19;
            book2.Rating = 7;
            book2.IsRented = true;
            book2.DateOfLoan = 05 - 05 - 23;
            book2.DateOfReturn = 30 - 06 - 23;

            Book book3 = new Book();
            book3.BookTitle = "Petter Northug";
            book3.Author = "Thor Gotaas";
            book3.Isbn = 766545343;
            book3.ReleaseDate = 14 - 09 - 14;
            book3.Rating = 5;
            book3.IsRented = false;
            book3.DateOfLoan = null;
            book3.DateOfReturn = null;

            

            Book book4 = new Book();
            book4.BookTitle = "Unstoppable - Max Verstappen";
            book4.Author = "Mark Hughes";
            book4.Isbn = 457654451;
            book4.ReleaseDate = 02 - 12 - 22;
            book4.Rating = 10;
            book4.IsRented = true;
            book4.DateOfLoan = 23 - 07 - 23;
            book4.DateOfReturn = 30 - 08 - 23;

            Book book5 = new Book();
            book5.BookTitle = "Haaland";
            book5.Author = "Lars Sivertsen";
            book5.Isbn = 896534114;
            book5.ReleaseDate = 22 - 08 - 21;
            book5.Rating = 3;
            book5.IsRented = false;
            book5.DateOfLoan = null;
            book5.DateOfReturn = null;


            Library library1 = new Library();
            library1.Name = "Nils Library";

            Customer customer1 = new Customer();
            customer1.FirstName = "Stefan";
            customer1.LastName = "Olsson";
            customer1.CardId = 2345678;
            customer1.CardPin = 2123;

            Customer customer2 = new Customer();
            customer2.FirstName = "Jocke";
            customer2.LastName = "Larsson";
            customer2.CardId = 3243456;
            customer2.CardPin = 1254;

            Customer customer3 = new Customer();
            customer3.FirstName = "Albin";
            customer3.LastName = "Rehnman";
            customer3.CardId = 1375432;
            customer3.CardPin = 1762;

        }
    }
}

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
            using (Context context = new Context())
            {

                // Skapa författare
                Author author1 = new Author { Name = "David Lagercrantz" };
                context.Authors.Add(author1);

                Author author2 = new Author { Name = "Ola Liljedahl" };
                context.Authors.Add(author2);

                Author author3 = new Author { Name = "Thor Gotaas" };
                context.Authors.Add(author3);

                Author author4 = new Author { Name = "Mark Hughes" };
                context.Authors.Add(author4);

                Author author5 = new Author { Name = "Lars Sivertsen" };
                context.Authors.Add(author5);


                // Skapa låntagare
                Customer customer1 = new Customer
                {
                    FirstName = "Stefan",
                    LastName = "Olsson",
                    CardId = 2345678,
                    CardPin = 2123
                    
                };
                

                Customer customer2 = new Customer
                {
                    FirstName = "Jocke",
                    LastName = "Larsson",
                    CardId = 3243456,
                    CardPin = 1254
                };
                

                Customer customer3 = new Customer
                {
                    FirstName = "Albin",
                    LastName = "Rehnman",
                    CardId = 1375432,
                    CardPin = 1762
                };
                

                Book book1 = new Book();
                book1.BookTitle = "Jag är Zlatan Ibrahimović";
                book1.Isbn = 234342323;              
                book1.Rating = 10;
                customer1.BooksBorrowed.Add(book1);
                book1.IsRented = true;
               

                Book book2 = new Book();
                book2.BookTitle = "Börje Salming";
                book2.Isbn = 267678312;
                book2.Rating = 9;
                customer2.BooksBorrowed.Add(book2);
                book2.IsRented = true;
                

                Book book3 = new Book();
                book3.BookTitle = "Petter Northug";
                book3.Isbn = 128956123;               
                book3.Rating = 6;
                customer3.BooksBorrowed.Add(book3);
                book3.IsRented = true;
                

                Book book4 = new Book();
                book4.BookTitle = "Unstoppable - Max Verstappen";
                book4.Isbn = 244342356;
                book4.IsRented = false;
                book4.Rating = 7;
                

                Book book5 = new Book();
                book5.BookTitle = "Haaland";
                book5.Isbn = 896724321;
                book5.IsRented = false;
                book5.Rating = 9;
                


                // Lägg till författare och böcker i context
                context.Authors.AddRange(author1, author2, author3, author4, author5);
                context.Books.AddRange(book1, book2, book3, book4, book5);


                // Lägg till låntagare i context
                context.Customers.AddRange(customer1, customer2, customer3);

                

                //// Låna några böcker för att testa
                BorrowBook(context, book1.Id, customer1.Id);
                BorrowBook(context, book2.Id, customer2.Id);
                BorrowBook(context, book3.Id, customer3.Id);

                // Spara ändringar i databasen
                context.SaveChanges();
            }
        }


       
        private void BorrowBook(Context context, int bookId, int customerId)
        {
            Book book = context.Books.Find(bookId);
            Customer customer = context.Customers.Find(customerId);

            if (book != null && customer != null)
            {
                // Uppdatera bokens låninformation
                book.IsRented = true;
                book.DateOfLoan = DateTime.Now;
                book.DateOfReturn = null;

                // Här sätter vi CustomerId på boken
                book.Id = customer.Id;

                // Lägg till boken i kundens lista över lånade böcker
                customer.BooksBorrowed.Add(book);

                // Spara ändringar i context
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Invalid book or invalid customer.");
            }
        }




        public void ReturnBook(int bookId)
        {
            using (Context context = new Context())
            {
                Book book = context.Books.Find(bookId);

                if (book != null && book.IsRented)
                {
                    book.IsRented = false;
                    book.DateOfReturn = DateTime.Now;

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Invalid book or book is not currently rented.");
                }
            }
        }

        public void DisplayBorrowedBooks(int cardNumber)
        {
            using (Context context = new Context())
            {
                Customer customer = context.Customers.Include(c => c.BooksBorrowed).FirstOrDefault(c => c.CardId == cardNumber);

                if (customer != null)
                {
                    Console.WriteLine($"Books borrowed by {customer.FirstName} {customer.LastName}:");
                    foreach (var book in customer.BooksBorrowed)
                    {
                        Console.WriteLine($"{book.BookTitle} by {book.Authors}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid customer.");
                }
            }
        }

        public void DeleteBorrower(int cardNumber)
        {
            using (Context context = new Context())
            {
                Customer customer = context.Customers.Find(cardNumber);

                if (customer != null)
                {
                    // Ta bort alla böcker som kunden har lånat
                    foreach (var book in customer.BooksBorrowed.ToList())
                    {
                        context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    }

                    context.Customers.Remove(customer);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Invalid customer.");
                }

            }
        }
    }
}

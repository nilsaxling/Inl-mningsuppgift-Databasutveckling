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
                

                Book book1 = new Book();
                book1.BookTitle = "Jag är Zlatan Ibrahimović";
                book1.Author = "David Lagercrantz";
                book1.Isbn = 987654321;
                book1.ReleaseDate = new DateTime(2022, 07, 22);
                book1.Rating = 9;
                book1.IsRented = false;  // Boken är inte lånad i början

                Book book2 = new Book();
                book2.BookTitle = "Börje Salming ";
                book2.Author = "Ola Liljedahl";
                book2.Isbn = 678645312;
                book2.ReleaseDate = new DateTime(2019, 10, 13);
                book2.Rating = 7;
                book2.IsRented = false;

                Book book3 = new Book
                {
                    BookTitle = "Petter Northug",
                    Author = "Thor Gotaas",
                    Isbn = 766545343,
                    ReleaseDate = new DateTime(2022, 07, 22),
                    Rating = 5,
                    DateOfLoan = null,
                    DateOfReturn = null
                };

                Book book4 = new Book
                {
                    BookTitle = "Unstoppable - Max Verstappen",
                    Author = "Mark Hughes",
                    Isbn = 457654451,
                    ReleaseDate = new DateTime(2018, 01, 02),
                    Rating = 10,
                    DateOfLoan = new DateTime(2023, 05, 22),
                    DateOfReturn = new DateTime(2023, 07, 01)
                };

                Book book5 = new Book
                {
                    BookTitle = "Haaland",
                    Author = "Lars Sivertsen",
                    Isbn = 896534114,
                    ReleaseDate = new DateTime(2022, 11, 06),
                    Rating = 3,
                    DateOfLoan = null,
                    DateOfReturn = null
                };

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

                context.Books.Add(book1);
                context.Books.Add(book2);
                context.Books.Add(book3);
                context.Books.Add(book4);
                context.Books.Add(book5);

                context.Customers.Add(customer1);
                context.Customers.Add(customer2);
                context.Customers.Add(customer3);

                // Låna några böcker för att testa
                BorrowBook(context, book1.BookId, customer1.CardId);
                BorrowBook(context, book2.BookId, customer2.CardId);
                BorrowBook(context, book3.BookId, customer3.CardId);

                context.SaveChanges();
            }
        }

        private void BorrowBook(Context context, int bookId, int cardNumber)
        {
            Book book = context.Books.Find(bookId);
            Customer customer = context.Customers.Find(cardNumber);

            if (book != null && customer != null)
            {
                book.DateOfLoan = DateTime.Now;
                book.DateOfReturn = null;

                customer.BooksBorrowed.Add(book);
            }
            else
            {
                Console.WriteLine("Invalid book or invalid customer.");
            }
        }

        public void BorrowBook(int bookId, int cardNumber)
        {
            using (Context context = new Context())
            {
                Book book = context.Books.Find(bookId);
                Customer customer = context.Customers.Find(cardNumber);

                if (book != null && customer != null && !book.IsRented)
                {
                    book.IsRented = true;
                    book.DateOfLoan = DateTime.Now;
                    book.DateOfReturn = null;

                    // Lägg till lånet i kundens historik
                    customer.BooksBorrowed.Add(book);

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Book not available for borrowing or invalid customer.");
                }
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
                        Console.WriteLine($"{book.BookTitle} by {book.Author}");
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

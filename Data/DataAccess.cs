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

                // Creates Authors
                Author author1 = new Author { Name = "David Lagercrantz" };
                

                Author author2 = new Author { Name = "Ola Liljedahl" };
                

                Author author3 = new Author { Name = "Thor Gotaas" };
                

                Author author4 = new Author { Name = "Mark Hughes" };
                

                Author author5 = new Author { Name = "Lars Sivertsen" };
                


                // Creates Customers
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
                
                //Creates Books
                Book book1 = new Book();
                book1.BookTitle = "Jag är Zlatan Ibrahimović";              
                book1.Rating = 10;
                book1.ReleaseDate = DateTime.Now;
                book1.IsRented = false;
               

                Book book2 = new Book();
                book2.BookTitle = "Börje Salming";
                book2.Isbn = 267678312;
                book2.Rating = 9;
                book2.ReleaseDate = DateTime.Now;
                book2.IsRented = false;
                

                Book book3 = new Book();
                book3.BookTitle = "Petter Northug";
                book3.Isbn = 128956123;               
                book3.Rating = 6;
                book3.ReleaseDate = DateTime.Now;
                book3.IsRented = false;
                

                Book book4 = new Book();
                book4.BookTitle = "Unstoppable - Max Verstappen";
                book4.Isbn = 244342356;
                book4.Rating = 7;
                book4.ReleaseDate = DateTime.Now;
                book4.IsRented = false;
                
                

                Book book5 = new Book();
                book5.BookTitle = "Haaland";
                book5.Isbn = 896724321;
                book5.Rating = 9;
                book5.ReleaseDate = DateTime.Now;
                book5.IsRented = false;
                
                

                //Add authors, books and customer to context
                
                context.Authors.AddRange(author1, author2, author3, author4, author5);
                context.Books.AddRange(book1, book2, book3, book4, book5);
                context.Customers.AddRange(customer1, customer2, customer3);


                context.SaveChanges();


                //Add loan for the books
               
                //Loan loan1 = new Loan { CustomerID = customer1.CustomerID, DateOfLoan = DateTime.Now, DateOfReturn = null };
                //Loan loan2 = new Loan { CustomerID = customer2.CustomerID, DateOfLoan = DateTime.Now, DateOfReturn = null };
                //Loan loan3 = new Loan { CustomerID = customer3.CustomerID, DateOfLoan = DateTime.Now, DateOfReturn = null };

                //context.Loans.AddRange(loan1, loan2, loan3);


                // Save changes in the database
                context.SaveChanges();
            }
        }


        public void AddCustomer(string firstName, string lastName) 
        {
            using (var context = new Context()) 
            {
                var newCustomer = new Customer 
                {
                    FirstName = firstName,
                    LastName = lastName,
                };

                context.Customers.Add(newCustomer);

                context.SaveChanges();


            }

        }
        public void AddBook(string bookTitle, DateTime? releaseDate, int rating, List<string> authorNames)
        {
            using (var context = new Context())
            {
                //Get existing authors or create new authors if they don't exist
                
                var authors = authorNames.Select(authorName =>
                {
                    var existingAuthor = context.Authors.FirstOrDefault(a => a.Name == authorName);
                    return existingAuthor ?? new Author { Name = authorName };
                }).ToList();

                var newBook = new Book
                {
                    BookTitle = bookTitle,
                    ReleaseDate = releaseDate,
                    Rating = rating,
                    Authors = authors  
                };

                //Add the new book to the list
                foreach (var author in authors)
                {
                    author.Books.Add(newBook);
                }

                context.Books.Add(newBook);
                context.SaveChanges();
            }
        }



        public void AddAuthor(string name)
        {
            using (var context = new Context())
            {
                var newAuthor = new Author
                {
                    Name = name,
                    
                };

                context.Authors.Add(newAuthor);

                context.SaveChanges();


            }
        }




        public void BorrowBook(int bookId, int customerId)
        {

            using (var context = new Context())
            {

                // Fetch the book and customer based on their IDs.              
                Book book = context.Books.Find(bookId);
                Customer customer = context.Customers.Find(customerId);

                // Check if the book and customer exist.
                if (book != null && customer != null)
                {
                    // Check if the book is avaible for loan.
                    if (book.Loan == null || book.Loan.DateOfReturn != null)
                    {
                        //  Instantiate a new LoanDetails object to track the loan details
                        var loanDetails = new Loan
                        {
                            BookID = book.BookID,
                            CustomerID = customer.CustomerID,
                            DateOfLoan = DateTime.Now,
                            DateOfReturn = null
                        };

                        //Update books loan information
                        book.Loan = loanDetails;
                        book.IsRented = true;

                        //Add loan details to the context
                        context.Loans.Add(loanDetails);

                        // Update the Loans property in the Customer class (an ICollection of LoanDetails).
                        customer.Loans.Add(loanDetails);

                        context.SaveChanges();

                        Console.WriteLine($"'{book.BookTitle}' has been rented to {customer.FirstName} {customer.LastName}.");
                    }
                    else
                    {
                        // If the book is already loaned out:
                        Console.WriteLine($"Sorry, {book.BookTitle} is already loaned out, please choose another book.");
                    }
                }
                else
                {
                    Console.WriteLine("Please make sure the book and customer exist before attempting to loan.");
                }
            }
        }




        public void ReturnBook(int bookId)
        {
            using (Context context = new Context())
            {
                // Fetch the book and explicitly load its Loan property.
                Book book = context.Books
                    .Include(b => b.Loan)
                    .FirstOrDefault(b => b.BookID == bookId);

                // Check if the book exists and is currently rented.
                if (book != null && book.IsRented)
                {
                    // Update book information to indicate it's no longer rented and set the return date.
                    book.IsRented = false;
                    book.Loan.DateOfReturn = DateTime.Now;

                    context.SaveChanges();

                    // Display a success message.
                    Console.WriteLine($"Book '{book.BookTitle}' has been returned.");
                }
                else
                {
                    // Display an error message if the book is not found or not currently rented.
                    Console.WriteLine("Invalid book or book is not currently rented.");
                }
            }
        }






        public void DeleteBorrower(int customerId)
        {
            Context context = new Context();

            // Find the customer to be deleted based on their ID.
            var borrowDelete = context.Customers.Find(customerId);
            
            // Check if the customer exists.
            if (borrowDelete != null)
            {
                // Deletes the customer from the context.
                context.Customers.Remove(borrowDelete);
                context.SaveChanges();
                Console.WriteLine($"'{borrowDelete.FirstName} {borrowDelete.LastName}' Has been removed.");
            }
            else
            {
                
                Console.WriteLine("Alreday been removed or has not been added");
            }
        }
        public void DeleteAuthor(int authorID)
        {
            using (Context context = new Context())
            {
                // Find the author to be deleted based on their ID.
                Author author = context.Authors.Find(authorID);
                
                // Check if the author exists.
                if (author != null)
                {


                    // Remove the author from the context.
                    context.Authors.Remove(author);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Invalid author.");
                }

            }
        }

        public void DeleteBook(int bookID)
        {
            using (Context context = new Context())
            {
                // Find the book to be deleted based on its ID.
                Book book = context.Books.Find(bookID);
               
                // Check if the book exists.
                if (book != null)
                {


                    // Remove the book from the context.
                    context.Books.Remove(book);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Invalid book.");
                }

            }
        }
    }
}

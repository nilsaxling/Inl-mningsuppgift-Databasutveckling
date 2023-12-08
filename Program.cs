using Inlämningsuppgift_Databasutveckling.Data;
using Inlämningsuppgift_Databasutveckling.Models;

namespace Inlämningsuppgift_Databasutveckling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataAccess dataAccess = new DataAccess();
            //1. Add initial data to the database (a seed method so that there is data to work
            //with for me without having to create everything from scratch).

            //dataAccess.Seed();

            //2.Create an Author
            //dataAccess.AddAuthor("Astrid Lindgren");
            //Console.WriteLine("Author has been added.");


            //3.Create a new book
            //List<string> authorNames = new List<string> { "Ingemar Jönsson" };
            //dataAccess.AddBook("Petter Northug", new DateTime(2023, 12, 08), 8, authorNames);
            //Console.WriteLine("Book has been added.");


            //4.Create a new customer
            //dataAccess.AddCustomer("Nils", "Axling");
            //Console.WriteLine("Customer has been added.");

            //5.Borrow a book
            //dataAccess.BorrowBook(1, 1);


            //6.Return a book
            //int bookIdToReturn = 1;
            //int customerIdReturning = 1;
            //dataAccess.ReturnBook(bookIdToReturn);

            //7. Delete customer
            //int borrowerIdToDelete = 3;
            //dataAccess.DeleteBorrower(borrowerIdToDelete);

            //Delete Book
            //int authorIdToDelete = 1;
            //dataAccess.DeleteAuthor(authorIdToDelete);
            //Console.WriteLine("Author has been deleted");

            //Delete Author
            //int bookIdToDelete = 3;
            //dataAccess.DeleteBook(bookIdToDelete);
            //Console.WriteLine("Book has been deleted.");





        }
    }
}
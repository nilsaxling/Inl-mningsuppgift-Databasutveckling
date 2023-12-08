using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsuppgift_Databasutveckling.Models
{
    internal class Loan
    {
        public int LoanID { get; set; } // Primary Key. 
        public int BookID { get; set; } // Foreign Key 
        public int CustomerID { get; set; } // Foreign Key
        public DateTime? DateOfLoan { get; set; }
        public DateTime? DateOfReturn { get; set; }

        // Connects the book and customer via the loan.
        public ICollection<Book> Books { get; set; } = new List<Book>(); // The reference to the loaned book.
        public Customer? Customer { get; set; } // The reference to the loaning customer.
    }
}

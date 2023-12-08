using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inlämningsuppgift_Databasutveckling.Models
{
    internal class Customer
    {
       
        public int CustomerID { get; set; } //Primary Key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CardId { get; set; }
        public int CardPin { get; set; }

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
        

        public Customer()
        {

        }
    }
}

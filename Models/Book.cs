using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inlämningsuppgift_Databasutveckling.Models
{
    internal class Book
    {
        //[Key]
        public int BookID { get; set; } //Primary key
        public string BookTitle { get; set; }
        public ICollection <Author> Authors { get; set; } = new List<Author>();
        public int Isbn { get; set; } = new Random().Next(10000000,999999999);
        public DateTime? ReleaseDate { get; set; }
        public int Rating { get; set; }
        public bool IsRented { get; set; }

        [ForeignKey("LoanID")]
        public Loan? Loan { get; set; }

        
       
    }
}

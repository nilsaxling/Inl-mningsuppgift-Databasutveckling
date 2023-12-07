using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inlämningsuppgift_Databasutveckling.Models
{
    internal class Book
    {
        //[Key]
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public ICollection <Author> Authors { get; set; } = new List<Author>();
        public int Isbn { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int Rating { get; set; }
        public bool IsRented { get; set; }
        public DateTime? DateOfLoan { get; set; }
        public DateTime? DateOfReturn { get; set; }

        
       
    }
}

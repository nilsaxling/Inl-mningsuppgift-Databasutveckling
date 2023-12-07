﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inlämningsuppgift_Databasutveckling.Models
{
    internal class Customer
    {
       //[Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CardId { get; set; }
        public int CardPin { get; set; }

        // Lägg till en ICollection för att representera böcker som kunden har lånat
        public ICollection<Book> BooksBorrowed { get; set; } = new List<Book>();

        public Customer()
        {

        }
    }
}

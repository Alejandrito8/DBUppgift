using System.Collections.Generic;

namespace Inlämning_DataBas.Models
{
    public class Book
    {
        public int ID { get; set; } // Primary Key
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public string Genre { get; set; }

        // Relation till många författare (via BookAuthor)
        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<Loan> Loans { get; set; } // property för Loans 
    }
}

using System.Collections.Generic;

namespace Inlämning_DataBas.Models
{
    public class Author
    {
        public int ID { get; set; } // Primary Key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Relation till många böcker (via BookAuthor)
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}

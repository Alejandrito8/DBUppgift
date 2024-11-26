namespace Inlämning_DataBas.Models
{
    public class BookAuthor
    {
        public int BookID { get; set; } // Foreign Key
        public Book Book { get; set; } // property för book

        public int AuthorID { get; set; } // Foreign Key
        public Author Author { get; set; } // property för author
    }
}

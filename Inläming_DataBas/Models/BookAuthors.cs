namespace Inlämning_DataBas.Models
{
    public class BookAuthor
    {
        public int BookId { get; set; } // Foreign Key
        public Book Book { get; set; } // Navigation property

        public int AuthorId { get; set; } // Foreign Key
        public Author Author { get; set; } // Navigation property
    }
}

using System;

namespace Inlämning_DataBas.Models
{
    public class Loan
    {
        public int Id { get; set; } // Primary Key
        public int BookId { get; set; } // Foreign Key
        public Book Book { get; set; } // Navigation property

        public string BorrowerName { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; } // Nullable for unreturned books
    }
}

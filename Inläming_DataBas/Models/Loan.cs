using System;

namespace Inlämning_DataBas.Models
{
    public class Loan
    {
        public int ID { get; set; } // Primary Key
        public int BookID { get; set; } // Foreign Key
        public Book Book { get; set; } // property för book

        public string BorrowerFirstName { get; set; }
        public string BorrowerLastName { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; } // Nullable för olämnade books
    }
}

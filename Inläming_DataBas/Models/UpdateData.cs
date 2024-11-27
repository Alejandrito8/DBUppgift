using Inlämning_DataBas.Models;
using Microsoft.EntityFrameworkCore;

public class UppdateData
{
    public static void BookAuthorRelation()
    {
        using (var context = new AppDbContext())
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                var book = new Book();
                var author = new Author();
                var bookAuthor = new BookAuthor
                {
                    BookID = book.ID,
                    AuthorID = author.ID
                };
                context.BookAuthors.Add(bookAuthor);
                context.SaveChanges();

                Console.WriteLine($"Book with ID {book.ID} and Author with ID {author.ID} have been linked.");
                transaction.Commit();
            }
        }
    }
    public static void BookLoan()
    {
        using (var context = new AppDbContext())
        {
            Console.WriteLine("Enter the first and last name of the borrower:");
            string borrowerName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(borrowerName))
            {
                Console.WriteLine("Invalid input. Please enter a valid first and last name.");
                return;
            }
            Console.WriteLine($"Borrower: {borrowerName}");

            Console.WriteLine("Enter the Book ID to loan:");
            if (!int.TryParse(Console.ReadLine(), out int bookId))
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric Book ID.");
                return;
            }

            Console.WriteLine("Enter the loan start date (YYYY-MM-DD):");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime loanDate))
            {
                Console.WriteLine("Invalid input. Please enter a valid date in YYYY-MM-DD format.");
                return;
            }

            Console.WriteLine("Enter the loan return date (YYYY-MM-DD):");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime returnDate))
            {
                Console.WriteLine("Invalid input. Please enter a valid date in YYYY-MM-DD format.");
                return;
            }

            var book = context.Books.Find(bookId);
            if (book == null)
            {
                Console.WriteLine($"No book found with ID {bookId}.");
                return;
            }

            var loan = new Loan
            {
                BorrowerName = borrowerName,
                BookID = bookId,
                LoanDate = loanDate,
                ReturnDate = returnDate
            };

            context.Loans.Add(loan);
            context.SaveChanges();

            Console.WriteLine($"Book '{book.Title}' with ID {bookId} has been loaned from {loanDate} to {returnDate}.");
        }
    }

}
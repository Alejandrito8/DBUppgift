using Inlämning_DataBas.Models;
using Microsoft.EntityFrameworkCore;

public class UppdateData
{
    public static void BookAuthorRelation()
    {
        try
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    System.Console.WriteLine("Enter the title of the book");
                    string title = Console.ReadLine().ToLower();
                    if (string.IsNullOrWhiteSpace(title))
                    {
                        throw new ArgumentException("Title cannot be empty");
                    }
                    var book = context.Books.FirstOrDefault(b => b.Title.ToLower() == title.ToLower());
                    if (book == null)
                    {
                        Console.WriteLine($"No book found with the title '{title}', but you can add it to the collection under 'add data' in the menu.");
                        return;
                    }
                    System.Console.WriteLine("Enter the first name for the author");
                    string firstName = Console.ReadLine().ToLower();
                    if (string.IsNullOrWhiteSpace(firstName))
                    {
                        throw new ArgumentException("First name cannot be empty");
                    }
                    Console.WriteLine("Enter the last name of the author");
                    string lastName = Console.ReadLine().ToLower();
                    if (string.IsNullOrWhiteSpace(lastName))
                    {
                        throw new ArgumentException("Last name cannot be empty");
                    }
                    var author = context.Authors
                        .FirstOrDefault(a => a.FirstName.ToLower() == firstName.ToLower() &&
                                             a.LastName.ToLower() == lastName.ToLower());
                    if (author == null)
                    {
                        Console.WriteLine($"No author found with the name '{firstName}' '{lastName}', but you can add the new author to the collection under 'add data' in the menu.");
                        return;
                    }

                    var bookAuthor = new BookAuthor
                    {
                        Book = book,
                        Author = author,
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
            catch (DbUpdateException ex)
    {
        Console.WriteLine($"Error: {ex.InnerException?.Message ?? ex.Message}");
    }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    public static void BookLoan()
    {
        try
        {
            using (var context = new AppDbContext())
            {
                Console.WriteLine("Enter the first name of the borrower:");
                string borrowerFirstName = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(borrowerFirstName))
                {
                    throw new ArgumentException("First name cannot be empty");
                }
                Console.WriteLine("Enter the last name of the borrower:");
                string borrowerLastName = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(borrowerLastName))
                {
                    throw new ArgumentException("Last name cannot be empty");
                }
                Console.WriteLine("Enter the name of the book to borrow:");
                string bookName = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(bookName))
                {
                    throw new ArgumentException("book title cannot be empty");
                }

                Console.WriteLine("Enter the loan start date (YYYY-MM-DD):");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime loanDate))
                {
                    throw new ArgumentException("Invalid date format. Please use yyyy-mm-dd");
                }

                Console.WriteLine("Enter the loan return date (YYYY-MM-DD):");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime returnDate))
                {
                    throw new ArgumentException("Invalid date format. Please use yyyy-mm-dd");
                }
                var book = context.Books
         .FirstOrDefault(b => b.Title.ToLower() == bookName.ToLower());

                if (book == null)
                {
                    Console.WriteLine($"No book found with the title '{bookName}', but you can add it to the collection under 'add data' in the menu.");
                    return;
                }

                var loan = new Loan
                {
                    BorrowerFirstName = borrowerFirstName,
                    BorrowerLastName = borrowerLastName,
                    BookID = book.ID,
                    LoanDate = loanDate,
                    ReturnDate = returnDate
                };

                context.Loans.Add(loan);
                context.SaveChanges();

                Console.WriteLine($"Book '{book.Title}' has been loaned to {borrowerFirstName} {borrowerLastName} from {loanDate.ToShortDateString()} to {returnDate.ToShortDateString()}.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
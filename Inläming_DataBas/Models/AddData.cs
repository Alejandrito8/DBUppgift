using Inlämning_DataBas.Models;
using Microsoft.EntityFrameworkCore;

public class AddData
{
    public static void CreateAuthor()
    {
        using (var context = new AppDbContext())
        {
            try
            {
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
                Console.WriteLine("Enter the date of birth of the author (yyyy-mm-dd)");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth))
                {
                    Console.WriteLine("Invalid date format. Please use yyyy-mm-dd");
                    return;
                }
                var author = new Author
                {
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = dateOfBirth
                };
                context.Authors.Add(author);
                context.SaveChanges();
                Console.WriteLine($"Author {firstName} {lastName} born {dateOfBirth} has been added to the database");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    public static void CreateBook()
    {
        using (var context = new AppDbContext())
        {
            try
            {
                System.Console.WriteLine("Enter the title of the book");
                string title = Console.ReadLine().ToLower();
                if (string.IsNullOrWhiteSpace(title))
                {
                    throw new ArgumentException("Title cannot be empty");
                }
                Console.WriteLine("Enter the genre of the book");
                string genre = Console.ReadLine().ToLower();
                if (string.IsNullOrWhiteSpace(genre))
                {
                    throw new ArgumentException("Genre cannot be empty");
                }
                Console.WriteLine("Enter the publication year of the book");
                if (!int.TryParse(Console.ReadLine(), out int publicationYear) || publicationYear < 0)
                {
                    throw new ArgumentException("Invalid date format. Please use yyyy-mm-dd");
                }
                var book = new Book
                {
                    Title = title,
                    PublicationYear = publicationYear,
                    Genre = genre,
                };
                context.Books.Add(book);
                context.SaveChanges();
                Console.WriteLine($"Book with the title {title} published in {publicationYear} with the genre {genre} has been added to the database");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    public static void CreateBookloan()
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
                Console.WriteLine("Enter the title of the book to borrow:");
                string bookTitle = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(bookTitle))
                {
                    throw new ArgumentException("Title cannot be empty");
                }
                var book = context.Books.FirstOrDefault(b => b.Title.ToLower() == bookTitle.ToLower());
                if (book == null)
                {
                    Console.WriteLine($"Book title cannot be empty");
                    return;
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
                if (loanDate > returnDate)
                {
                    System.Console.WriteLine("Start date cannot be after return date");
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
                Console.WriteLine($"Loan ID: {loan.ID} - Book '{bookTitle}' has been loaned to {borrowerFirstName} {borrowerLastName} from {loanDate.ToShortDateString()} to {returnDate.ToShortDateString()}.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

}




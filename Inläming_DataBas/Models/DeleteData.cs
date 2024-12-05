using Inlämning_DataBas.Models;
using Microsoft.EntityFrameworkCore;
public class DeleteData
{
    public static void DeleteAuthor()
    {
        using (var context = new AppDbContext())
        {
            try
            {
                System.Console.WriteLine("Enter the first name for the author you want to delete from the database");
                string firstName = Console.ReadLine()?.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(firstName))
                {
                    throw new ArgumentException("First name cannot be empty");
                }
                Console.WriteLine("Enter the last name of the author you want to delete from the database");
                string lastName = Console.ReadLine()?.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    throw new ArgumentException("Last name cannot be empty");
                }
                var author = context.Authors
                .FirstOrDefault(a => a.FirstName.ToLower() == firstName && a.LastName.ToLower() == lastName);

                if (author == null)
                {
                    Console.WriteLine($"Invalid input. Try again");
                    return;
                }

                Console.WriteLine($"Author found: {author.FirstName} {author.LastName}. Do you want to delete this author? write: 'yes' or 'no'.");
                string confirmation = Console.ReadLine()?.ToLower();

                if (confirmation == "yes")
                {
                    context.Authors.Remove(author);
                    context.SaveChanges();
                    Console.WriteLine($"Author {author.FirstName} {author.LastName} has been deleted from the database.");
                }
                else if (confirmation == "no")
                {
                    Console.WriteLine("Deletion canceled.");
                }
                else
                {
                    Console.WriteLine("Deletion canceled, please answer: 'yes' or 'no'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    public static void DeleteBook()
    {
        using (var context = new AppDbContext())
        {
            try
            {
                System.Console.WriteLine("Enter the title of the book you want to delete from the database");
                string title = Console.ReadLine()?.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(title))
                {
                    throw new ArgumentException("Book title cannot be empty");
                }
                var book = context.Books.FirstOrDefault(b => b.Title.ToLower() == title);

                if (book == null)
                {
                    Console.WriteLine($"Invalid input. Try again");
                    return;
                }

                Console.WriteLine($"Book found: {book.Title}. Do you want to delete this author? write: 'yes' or 'no'.");
                string confirmation = Console.ReadLine()?.ToLower();

                if (confirmation == "yes")
                {
                    context.Books.Remove(book);
                    context.SaveChanges();
                    Console.WriteLine($"Book {book.Title} has been deleted from the database.");
                }
                else if (confirmation == "no")
                {
                    Console.WriteLine("Deletion canceled.");
                }
                else
                {
                    Console.WriteLine("Deletion canceled, please answer: 'yes' or 'no'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    public static void DeleteBookloan()
    {
        using (var context = new AppDbContext())
        {
            try
            {
                System.Console.WriteLine("Enter the ID of the book loan you want to delete from the database");
                string LoanId = Console.ReadLine()?.Trim().ToLower();
                if (!int.TryParse(LoanId, out int loanId))
                {
                    throw new ArgumentException("Invalid input. Try again");
                }
                var loan = context.Loans
                .Include(l => l.Book)
                .FirstOrDefault(l => l.ID == loanId);

                if (loan == null)
                {
                    Console.WriteLine($"Invalid input. Try again");
                    return;
                }

                Console.WriteLine($"Loan found for book: {loan.Book.Title}. Borrowed by {loan.BorrowerFirstName} {loan.BorrowerLastName} on {loan.LoanDate:yyyy-MM-dd}. Due date: {loan.DueDate:yyyy-MM-dd}. Do you want to delete this author? write: 'yes' or 'no'.");
                string confirmation = Console.ReadLine()?.ToLower();

                if (confirmation == "yes")
                {
                    context.Loans.Remove(loan);
                    context.SaveChanges();
                    Console.WriteLine($"Loan with ID '{loanId}' and title '{loan.Book.Title}'  has been deleted from the database.");
                }
                else if (confirmation == "no")
                {
                    Console.WriteLine("Deletion canceled.");
                }
                else
                {
                    Console.WriteLine("Deletion canceled, please answer: 'yes' or 'no'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
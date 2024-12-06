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
                    System.Console.WriteLine("Enter the current title of the book");
                    string title = Console.ReadLine().ToLower();
                    if (string.IsNullOrWhiteSpace(title))
                    {
                        throw new ArgumentException("Title cannot be empty");
                    }
                    var book = context.Books.FirstOrDefault(b => b.Title.ToLower() == title.ToLower());
                    if (book == null)
                    {
                        Console.WriteLine("The book does not exist in the database");
                        return;
                    }
                    System.Console.WriteLine("Enter the first name for the current author");
                    string firstName = Console.ReadLine().ToLower();
                    if (string.IsNullOrWhiteSpace(firstName))
                    {
                        throw new ArgumentException("First name cannot be empty");
                    }
                    Console.WriteLine("Enter the last name of the current author");
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
                        Console.WriteLine("The author does not exist in the database");
                        return;
                    }
                    var existingRelation = context.BookAuthors
                    .FirstOrDefault(ba => ba.BookID == book.ID && ba.AuthorID == author.ID);

                    if (existingRelation == null)
                    {
                        Console.WriteLine($"No relation found between the book '{title}' and author '{firstName} {lastName}'");
                        return;
                    }
                    Console.WriteLine("Enter the new title of the book");
                    string newTitle = Console.ReadLine().ToLower();
                    if (!string.IsNullOrWhiteSpace(newTitle))
                    {
                        book.Title = newTitle;
                    }

                    Console.WriteLine("Enter the new first name of the author");
                    string newFirstName = Console.ReadLine().ToLower();
                    if (!string.IsNullOrWhiteSpace(newFirstName))
                    {
                        author.FirstName = newFirstName;
                    }

                    Console.WriteLine("Enter the new last name of the author");
                    string newLastName = Console.ReadLine().ToLower();
                    if (!string.IsNullOrWhiteSpace(newLastName))
                    {
                        author.LastName = newLastName;
                    }

                    context.SaveChanges();
                    Console.WriteLine($"The book '{book.Title}'with ID {book.ID} and the author '{author.FirstName} {author.LastName}' with ID {author.ID} have been linked");
                }
            }
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
                Console.WriteLine("Enter the ID of the loan you want to update:");
                if (!int.TryParse(Console.ReadLine(), out int loanId))
                {
                    throw new ArgumentException("Invalid loan ID");
                }

                var loan = context.Loans.Include(l => l.Book).FirstOrDefault(l => l.ID == loanId);
                if (loan == null)
                {
                    Console.WriteLine($"The loan Id does not exist in the database");
                    return;
                }
                Console.WriteLine("Current Loan Details:");
                Console.WriteLine($"Loan ID: {loan.ID}, Book: {loan.Book.Title}, Borrower:{loan.BorrowerFirstName} {loan.BorrowerLastName} \n Loan Date: {loan.LoanDate.ToShortDateString()}, Return Date: {loan.ReturnDate}");
                
                Console.WriteLine("Enter the new borrower's last name (or leave blank to keep the current)");
                string newFirstName = Console.ReadLine()?.ToLower();
                if (!string.IsNullOrWhiteSpace(newFirstName))
                {
                    loan.BorrowerFirstName = newFirstName;
                }
                Console.WriteLine("Enter the new borrower's last name (or leave blank to keep the current)");
                string newLastName = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(newLastName))
                {
                    loan.BorrowerLastName = newLastName;
                }

                Console.WriteLine("Enter the new loan start date (YYYY-MM-DD) (or leave blank to keep the current)");
                string newLoanDateInput = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(newLoanDateInput) && DateTime.TryParse(newLoanDateInput, out DateTime newLoanDate))
                {
                    loan.LoanDate = newLoanDate;
                }

                Console.WriteLine("Enter the new return date (YYYY-MM-DD) (or leave blank to keep the current)");
                string newReturnDateInput = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(newReturnDateInput) && DateTime.TryParse(newReturnDateInput, out DateTime newReturnDate))
                {
                    loan.ReturnDate = newReturnDate;
                }
                context.SaveChanges();
                Console.WriteLine("Loan updated successfully");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
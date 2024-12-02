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
            string firstName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(firstName))
                {
                    throw new ArgumentException("First name cannot be empty");
                }
            Console.WriteLine("Enter the last name of the author");
            string lastName = Console.ReadLine();
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
            Console.WriteLine($"Author {firstName} {lastName} born {dateOfBirth} has been added");
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
            string title = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(title))
                {
                    throw new ArgumentException("Title cannot be empty");
                }
            Console.WriteLine("Enter the genre of the book");
            string genre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(genre))
                {
                    throw new ArgumentException("Genre cannot be empty");
                }
            Console.WriteLine("Enter the publication year of the book");
            if (!int.TryParse(Console.ReadLine(), out int publicationYear) || publicationYear < 0)
            {
                throw new ArgumentException ("Invalid date format. Please use yyyy-mm-dd");
            }
             var book = new Book
            {
                Title = title,
                PublicationYear = publicationYear,
                Genre = genre,
            };
            context.Books.Add(book);
            context.SaveChanges();
            Console.WriteLine($"Book with the title {title} published in {publicationYear} with the genre {genre} has been added.");
            }
            catch (Exception ex)
            {                
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}



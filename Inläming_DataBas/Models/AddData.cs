using Inlämning_DataBas.Models;
using Microsoft.EntityFrameworkCore;

public class AddData
{
    public static void CreateAuthor()
    {
        using (var context = new AppDbContext())
        {
            var author = new Author
            {
                FirstName = "Aleksandar",
                LastName = "Jurkovic",
                DateOfBirth = new DateTime(1775, 12, 16)
            };
            context.Authors.Add(author);
            context.SaveChanges();
        }
    }
    public static void CreateBook()
    {
        using (var context = new AppDbContext())
        {
            var book = new Book

            {
                Title = "Aleksandar The Great",
                PublicationYear = 1813,
                Genre = "ActionDrama",
            };
            context.Books.Add(book);
            context.SaveChanges();
        }
    }
}



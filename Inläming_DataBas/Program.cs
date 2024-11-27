using Inlämning_DataBas.Models;
using Microsoft.EntityFrameworkCore;

using (var context = new AppDbContext())
{
    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            var author = new Author
            {
                FirstName = "Aleksandar",
                LastName = "Jurkovic",
                DateOfBirth = new DateTime(1775, 12, 16)
            };
            context.Authors.Add(author);
            context.SaveChanges(); 

            var book = new Book
            {
                Title = "Aleksandar The Great",
                PublicationYear = 1813,
                Genre = "ActionDrama",
            };
            context.Books.Add(book);
            context.SaveChanges(); 

            var bookAuthor = new BookAuthor
            {
                BookID = book.ID,
                AuthorID = author.ID
            };
            context.BookAuthors.Add(bookAuthor);
            context.SaveChanges();


            transaction.Commit();
            Console.WriteLine("The book and the author have been added and related.");
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Console.WriteLine("Oops... A problem occured: " + ex.Message);
        }
    }
}


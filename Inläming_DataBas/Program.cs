using System.Diagnostics;
using Inlämning_DataBas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

class Program
{
    static void Main(string[] args)
    {
        bool Menu = true;
        while (Menu)
        {
            System.Console.WriteLine("What do you want to do?");
            System.Console.WriteLine("1. Add Data");
            System.Console.WriteLine("2. Update Data");
            System.Console.WriteLine("3. Delete Data");
            System.Console.WriteLine("4. List Data");
            System.Console.WriteLine("5. Quit");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    System.Console.WriteLine("What data do you want to add?");
                    System.Console.WriteLine("1. Add an Author");
                    System.Console.WriteLine("2. Add a book");
                    System.Console.WriteLine("3. Add a bookloan");
                    System.Console.WriteLine("4. Quit");
                    var input1 = Console.ReadLine();
                    {
                        if (input1 == "1")
                        {
                            AddData.CreateAuthor();
                            break;
                        }
                        else if (input1 == "2")
                        {
                            AddData.CreateBook();
                        }
                        else if (input1 == "3")
                        {
                            AddData.CreateBookloan();
                            break;
                        }
                        else if (input1 == "4")
                        {
                            System.Console.WriteLine("Exiting program");
                            return;
                        }
                        else
                        {
                            System.Console.WriteLine("Oops... A problem occured");
                            break;
                        }
                    }
                    break;

                case "2":
                    System.Console.WriteLine("What data do you want to update?");
                    System.Console.WriteLine("1. Update Book & Author relation");
                    System.Console.WriteLine("2. Update Bookloan & Borrower");
                    System.Console.WriteLine("3. Quit");
                    var input2 = Console.ReadLine();


                    if (input2 == "1")
                    {
                        UppdateData.BookAuthorRelation();
                        break;
                    }
                    else if (input2 == "2")
                    {
                        UppdateData.BookLoan();
                        break;
                    }
                    else if (input2 == "3")
                    {
                        System.Console.WriteLine("Exiting program");
                        return;
                    }
                    else
                    {
                        System.Console.WriteLine("Oops... A problem occured");
                        break;
                    }

                case "3":
                    System.Console.WriteLine("What data do you want to Delete?");
                    System.Console.WriteLine("1. Delete Author");
                    System.Console.WriteLine("2. Delete Book");
                    System.Console.WriteLine("3. Delete bookloan");
                    System.Console.WriteLine("4. Quit");
                    var input3 = Console.ReadLine();

                    if (input3 == "1")
                    {
                        DeleteData.DeleteAuthor();
                        break;
                    }
                    else if (input3 == "2")
                    {
                        DeleteData.DeleteBook();
                        break;
                    }
                    else if (input3 == "3")
                    {
                        DeleteData.DeleteBookloan();
                        break;
                    }
                    else if (input3 == "4")
                    {
                        System.Console.WriteLine("Exiting program");
                        return;
                    }
                    else
                    {
                        System.Console.WriteLine("Oops... A problem occured");
                        break;
                    }

                case "4":
                    System.Console.WriteLine("What data do you want to List?");
                    System.Console.WriteLine("1. List books and authors");
                    System.Console.WriteLine("2. List loaned books");
                    System.Console.WriteLine("3. List books by one author");
                    System.Console.WriteLine("4. List every author for one book");
                    System.Console.WriteLine("5. Quit");
                    var input4 = Console.ReadLine();

                    if (input4 == "1")
                    {
                        ListData.ListBooksAndAuthors();
                        break;
                    }
                    else if (input4 == "2")
                    {
                        ListData.ListLoanedBooks();
                        break;
                    }
                    else if (input4 == "3")
                    {
                        ListData.ListBooksByAuthor();
                        break;
                    }
                    else if (input4 == "4")
                    {
                        ListData.ListAuthorsForBook();
                        break;
                    }
                    else if (input4 == "5")
                    {
                        System.Console.WriteLine("Exiting program");
                        return;
                    }
                    else
                    {
                        System.Console.WriteLine("Oops... A problem occured");
                        break;
                    }

                case "5":
                    System.Console.WriteLine("Exiting program");
                    return;

                default:
                    System.Console.WriteLine("Oops... A problem occured");
                    break;
            }
        }

    }
}

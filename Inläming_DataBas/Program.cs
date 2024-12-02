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
            System.Console.WriteLine("2. Update data");
            System.Console.WriteLine("3. Delete data");
            System.Console.WriteLine("4. Quit");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    System.Console.WriteLine("What data do you want to add?");
                    System.Console.WriteLine("1. Add an Author");
                    System.Console.WriteLine("2. Add a book");
                    System.Console.WriteLine("3. Quit");
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
                    System.Console.WriteLine("2. Update Book & Borrower ");
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
                    System.Console.WriteLine("3. Delete Borrower");
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
                        DeleteData.DeleteBorrower();
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
                    System.Console.WriteLine("Exiting program");
                    return;

                default:
                    System.Console.WriteLine("Oops... A problem occured");
                    break;
            }
        }

    }
}

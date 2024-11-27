using System.Diagnostics;
using Inlämning_DataBas.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {

        System.Console.WriteLine("What do you want to do?");
        System.Console.WriteLine("1. Add Data");
        System.Console.WriteLine("2. Update data");
        System.Console.WriteLine("3. Delete data");
        System.Console.WriteLine("4. Quit");



        var input = Console.ReadLine();
        bool Menu = true;
        while (Menu)
        {
            switch (input)
            {
                case "1":
                    var input1 = Console.ReadLine();
                    bool Menu1 = true;
                    while (Menu1)
                    {
                        System.Console.WriteLine("What data do you want to add?");
                        System.Console.WriteLine("1. Create an Author");
                        System.Console.WriteLine("2. Create a book");
                        System.Console.WriteLine("3. Quit");
                        if (input1 == "1")
                        {
                            AddData.CreateAuthor();
                        }
                        else if (input1 == "2")
                        {
                            AddData.CreateBook();
                        }
                        else if (input1 == "3")
                        {
                            System.Console.WriteLine("Exiting program");
                            Menu1 = false;
                        }
                        else
                        {
                            Console.WriteLine("Oops... A problem occured");
                        }
                    }
                    break;

                case "2":
                    var input2 = Console.ReadLine();
                    bool Menu2 = true;
                    while (Menu2)
                    {
                        System.Console.WriteLine("What data do you want to update?");
                        System.Console.WriteLine("1. Update Book & Author relation");
                        System.Console.WriteLine("2. Update Book & Borrower ");
                        System.Console.WriteLine("3. Quit");

                        if (input2 == "1")
                        {
                            UppdateData.BookAuthorRelation();
                        }
                        else if (input2 == "2")
                        {
                            UppdateData.BookLoan();
                        }
                        else if (input2 == "3")
                        {
                            System.Console.WriteLine("Exiting program");
                            Menu2 = false;
                        }
                        else
                        {
                            Console.WriteLine("Oops... A problem occured");
                        }
                    }
                    break;

                case "3":
                    var input3 = Console.ReadLine();
                    bool Menu3 = true;
                    while (Menu3)
                    {
                        System.Console.WriteLine("What data do you want to Delete?");
                        System.Console.WriteLine("1. Delete Author");
                        System.Console.WriteLine("2. Delete Book");
                        System.Console.WriteLine("3. Delete Borrower");
                        System.Console.WriteLine("4. Quit");
                        if (input3 == "1")
                        {
                            DeleteData.DeleteAuthor();
                        }
                        else if (input3 == "2")
                        {
                            DeleteData.DeleteBook();
                        }
                        else if (input3 == "3")
                        {
                            DeleteData.DeleteBorrower();
                        }
                        else if (input3 == "4")
                        {
                            System.Console.WriteLine("Exiting program");
                            Menu2 = false;
                        }
                        else
                        {
                            Console.WriteLine("Oops... A problem occured");
                        }
                    }
                    break;

                case "4":
                    System.Console.WriteLine("Exiting program");
                    Menu = false;
                    break;

                default:
                    Console.WriteLine("Oops... A problem occured");
                    return;

            }
        }
    }
}

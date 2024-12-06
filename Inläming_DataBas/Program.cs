﻿using System.Diagnostics;
using Inlämning_DataBas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

class Program
{
    static void Main(string[] args)
    {
        try
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
                var input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "1":
                    {
                        Console.Clear();
                        MenuData.HandleData();
                        break;
                    }
                    case "2":
                    {
                        Console.Clear();
                        MenuData.HandleUpdateData();
                        break;
                    }
                    case "3":
                    {
                        Console.Clear();
                        MenuData.HandleDeleteData();
                        break;
                    }
                    case "4":
                    {
                        Console.Clear();
                        MenuData.HandleListData();
                        break;
                    }
                    case "5":
                        Console.Clear();
                        System.Console.WriteLine("Exiting program");
                        return;

                    default:
                        Console.Clear();
                        System.Console.WriteLine("Oops... A problem occured");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR... {ex}");
        }

    }
}

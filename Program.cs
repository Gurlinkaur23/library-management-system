using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Program
    {
        /// <summary>
        /// The main method is responsible for creating different data structures and creating objects of classes.
        /// It also calls the methods from the classes based on the user choice.
        /// 
        /// The overall time complexity of this method depends on the specific operations within the called methods. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // user is librarian / admin

            // Create different data structures for managing the books in the library
            Dictionary<int, List<string>> booksInLibrary = new Dictionary<int, List<string>>();
            List<string> listOfBookTitles = new List<string>();
            Dictionary<string, List<string>> listOfGenresAndTitles = new Dictionary<string, List<string>>();

            try
            {
                // Create objects of different classes
                AddBooks addBooksObject = new AddBooks();
                ViewBooks viewBooksObject = new ViewBooks();
                SearchBooks searchBooksObject = new SearchBooks();
                BorrowAndReturnBooks borrowAndReturnBooksObject = new BorrowAndReturnBooks();

                Console.WriteLine("- * - * - * - * - * - * - * - * - ");
                Console.WriteLine("   LIBRARY MANAGEMENT SYSTEM");

                bool userWantsToContinueTheApp = true;

                while (userWantsToContinueTheApp)
                {
                    // Give the user options to choose from
                    Console.WriteLine("- * - * - * - * - * - * - * - * - ");
                    Console.WriteLine();
                    Console.WriteLine("Choose a number from the given options:");
                    Console.WriteLine("1. Add a book to the library.");
                    Console.WriteLine("2. View books from the library.");
                    Console.WriteLine("3. Search a book from library.");
                    Console.WriteLine("4. Borrow a book from the library.");
                    Console.WriteLine("5. Return a book to the library.");
                    Console.WriteLine("6. Exit");
                    Console.WriteLine();

                    Console.Write("Select option: ");
                    string userChoice = Console.ReadLine().Trim();
                    Console.WriteLine();

                    if (int.TryParse(userChoice, out int choice) && choice > 0 && choice <= 6)
                    {
                        // Call the methods from different class files
                        switch (choice)
                        {
                            case 1:
                                addBooksObject.AddBooksToLibrary(booksInLibrary, listOfBookTitles, listOfGenresAndTitles);
                                break;
                            case 2:
                                if (booksInLibrary.Count > 0)
                                    viewBooksObject.OptionsToViewBooks(listOfGenresAndTitles, booksInLibrary);
                                else
                                    Console.WriteLine("There are currently no books in the library!");
                                break;
                            case 3:
                                if (booksInLibrary.Count > 0)
                                    searchBooksObject.OptionsToSearchBooks(booksInLibrary, listOfBookTitles);
                                else
                                    Console.WriteLine("There are currently no books in the library!");
                                break;
                            case 4:
                                if (booksInLibrary.Count > 0)
                                    borrowAndReturnBooksObject.BorrowBook(booksInLibrary, listOfBookTitles);
                                else
                                    Console.WriteLine("There are currently no books in the library!");
                                break;
                            case 5:
                                if (booksInLibrary.Count > 0)
                                    borrowAndReturnBooksObject.ReturnBook(booksInLibrary, listOfBookTitles);
                                else
                                    Console.WriteLine("There are currently no books in the library!");
                                break;
                            case 6:
                                Console.WriteLine("Exiting the application.");
                                userWantsToContinueTheApp = false;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Please choose a valid number for the options.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                Console.ReadKey();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class BorrowAndReturnBooks
    {
        /// <summary>
        /// This method validates the user input book title. It checks if the title is null or white space.
        /// If the title input is invalid, then it prompts the user to input the title again.
        /// 
        /// Big-O Notation: O(n) Linear time complexity
        /// The time complexity is linear. Here, 'n' is the length of the title input. This method loops through the input
        /// string to check if it is null or white space
        /// </summary>
        /// <param name="titleOfBook"></param>
        /// <param name="listOfBookTitles"></param>
        /// <returns></returns>
        public bool ValidateInputTitleOfBook(string titleOfBook, List<string> listOfBookTitles)
        {
            while (
                string.IsNullOrWhiteSpace(titleOfBook))
            //|| !listOfBookTitles.Any(title => title.ToLower() == titleOfBook.ToLower()))
            {
                Console.WriteLine("Invalid title. Please enter a valid title of the book.");

                Console.WriteLine();
                Console.Write("Enter the title of the book: ");
                titleOfBook = Console.ReadLine().Trim().ToLower();
            }

            // User input is correct
            return true;
        }

        /// <summary>
        /// This method first calls the above validation method. Then it loops through the books dictionary and checks if
        /// the input book title exists in the books dictionary. Then, it checks the status of the book. If it is 'Available',
        /// then it allows the use to borrow the book and updates the status of the book to 'Borrowed'. Otherwise, 
        /// it tells the user that the book is already borrowed.
        /// 
        /// Big-O Notation: O(n) Linear time complexity
        /// Here, 'n' is the number of books in the library.
        /// The loop iterates through each book in the list, resulting in linear time complexity.
        /// </summary>
        /// <param name="booksInLibarary"></param>
        /// <param name="listOfBookTitles"></param>
        public void BorrowBook(Dictionary<int, List<string>> booksInLibarary, List<string> listOfBookTitles)
        {
            Console.Write("Enter the title of the book you want to borrow: ");
            string titleOfBook = Console.ReadLine().Trim().ToLower();
            Console.WriteLine();

            // Check for the validity of the input title of book
            bool isUserInputCorrect = ValidateInputTitleOfBook(titleOfBook, listOfBookTitles);

            if (isUserInputCorrect)
            {
                foreach (var keyValuePair in booksInLibarary)
                {
                    // Get the list of book details from the booksInLibrary dictionary
                    List<string> bookDetails = keyValuePair.Value;

                    if (bookDetails[0].ToLower() == titleOfBook)
                    {
                        // Check the availability of the book
                        if (bookDetails[4] == "Available")
                        {
                            Console.WriteLine($"The book with ID {keyValuePair.Key} and title '{bookDetails[0]}'" +
                                $" has been borrowed.");

                            // Update the status of the book
                            bookDetails[4] = "Borrowed";

                            break;
                        }
                        else
                        {
                            Console.WriteLine($"The book with ID {keyValuePair.Key} and title '{bookDetails[0]}' " +
                                $"has already been borrowed.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The book you entered doesnot exist in the library.");
                    }
                }
            }
        }

        /// <summary>
        /// This method first calls the above validation method. Then it loops through the books dictionary and checks if
        /// the input book title exists in the books dictionary. Then, it checks the status of the book. If it is 'Borrowed',
        /// then it allows the use to return the book and updates the status of the book to 'Available'. Otherwise, 
        /// it tells the user that the book has not been borrowed.
        /// 
        /// Big-O Notation: O(n) Linear time complexity
        /// Here, 'n' is the number of books in the library.
        /// The loop iterates through each book in the list, resulting in linear time complexity.
        /// </summary>
        /// <param name="booksInLibarary"></param>
        /// <param name="listOfBookTitles"></param>
        public void ReturnBook(Dictionary<int, List<string>> booksInLibarary, List<string> listOfBookTitles)
        {
            // Check if there are any borrowed books. If not display the message to user
            if (booksInLibarary.Any(book => book.Value[4] == "Borrowed"))
            {
                Console.Write("Enter the title of the book you want to return: ");
                string titleOfBook = Console.ReadLine().Trim().ToLower();
                Console.WriteLine();

                // Check for the validity of the input title of book
                bool isUserInputCorrect = ValidateInputTitleOfBook(titleOfBook, listOfBookTitles);

                if (isUserInputCorrect)
                {
                    foreach (var keyValuePair in booksInLibarary)
                    {
                        // Get the list of book details from the booksInLibrary dictionary
                        List<string> bookDetails = keyValuePair.Value;

                        if (bookDetails[0].ToLower() == titleOfBook)
                        {
                            // Check the availability of the book
                            if (bookDetails[4] == "Borrowed")
                            {
                                Console.WriteLine($"The book with ID {keyValuePair.Key} and title '{bookDetails[0]}'" +
                                    $" has been returned.");

                                // Update the status of the book
                                bookDetails[4] = "Available";

                                break;
                            }
                            else
                            {
                                Console.WriteLine($"The book with ID {keyValuePair.Key} and title '{bookDetails[0]}' " +
                                    $"has not been borrowed.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("The book you entered doesnot exist in the library.");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("There are no borrowed books in library to return yet.");
            }
        }
    }
}

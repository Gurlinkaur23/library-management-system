using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class SearchBooks
    {
        /// <summary>
        /// This method allows the user to search a book by the title name, author name and by ID. The user selects an option
        /// and the response is validated. Then, a switch case is used to call the appropriate method to handle the
        /// search operation.
        /// 
        /// Big-O Notation: O(n) - Linear time complexity.
        /// The SearchBookByTitle and SearchBookByAuthor methods are of linear complexity due to the loops.
        /// The loop runs once for each book title in the list, resulting in linear time complexity.
        /// This makes OptionsToSearchBooks method of linear complexity.
        /// </summary>
        /// <param name="booksInLibarary"></param>
        /// <param name="listOfBookTitles"></param>
        public void OptionsToSearchBooks(Dictionary<int, List<string>> booksInLibarary, List<string> listOfBookTitles)
        {
            try
            {
                bool isUserInputInCorrect = true;
                while (isUserInputInCorrect)
                {
                    Console.WriteLine();
                    Console.WriteLine("Choose a number from the given options to search a book:");
                    Console.WriteLine("1. Search a book by title.");
                    Console.WriteLine("2. Seach a book by author.");
                    Console.WriteLine("3. Seach a book by ID.");
                    Console.WriteLine();

                    Console.Write("Select option: ");
                    string userChoice = Console.ReadLine().Trim();
                    Console.WriteLine();

                    if (int.TryParse(userChoice, out int choice) && choice > 0 && choice <= 3)
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.Write("Please enter the title of the book: ");
                                string tagetBookTitle = Console.ReadLine().Trim().ToLower();
                                Console.WriteLine();
                                // Big-O Notation: O(n) - Linear
                                SearchBookByTitle(listOfBookTitles, tagetBookTitle, booksInLibarary);
                                break;
                            case 2:
                                Console.Write("Please enter the author of the book: ");
                                string tagetBookAuthor = Console.ReadLine().Trim().ToLower();
                                Console.WriteLine();
                                // Big-O Notation: O(n) - Linear
                                SearchBookByAuthor(tagetBookAuthor, booksInLibarary);
                                break;
                            case 3:
                                // Big-O Notation: O(1) - Constant
                                SearchBookById(booksInLibarary);
                                break;
                        }
                        isUserInputInCorrect = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Please choose a valid number for the options.");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This method loops through a list of book titles and checks if the user input title of book (target) exists in the
        /// list. If so, then it creates a list of book details from the books dictionary and displays a formatted string
        /// for the searched book.
        /// This method implements "LINEAR SEARCH Algorithm".
        /// 
        /// Big-O Notation: O(n) - Linear time complexity
        /// Due to the loop that searches through the list of book titles.
        /// The loop iterates through each book title in the list, resulting in linear time complexity.
        /// </summary>
        /// <param name="listOfBookTitles"></param>
        /// <param name="targetBookTitle"></param>
        /// <param name="booksInLibarary"></param>
        public void SearchBookByTitle(
            List<string> listOfBookTitles,
            string targetBookTitle,
            Dictionary<int, List<string>> booksInLibarary)
        {
            bool bookFound = false;

            for (int i = 0; i < listOfBookTitles.Count; i++)
            {
                if (listOfBookTitles[i].ToLower() == targetBookTitle)
                {
                    // Get the list of book details from the booksInLibrary dictionary
                    List<string> bookDetails = booksInLibarary[i + 1];

                    Console.WriteLine($"Book ID: {i + 1}, Title: {bookDetails[0]}, Author: {bookDetails[1]}, " +
                     $"Publication year: {bookDetails[2]}, Genre: {bookDetails[3]}, Status: {bookDetails[4]}");
                    Console.WriteLine("-  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -");
                    bookFound = true;
                }
            }
            if (!bookFound)
            {
                Console.WriteLine("The book you searched for doesnot exist in the library.");
            }
        }

        /// <summary>
        /// This method loops through the books dictionary and gets the list of book details. From the book details, it gets the
        /// author. Then, it matches the author with the user input author (target). If the match is successful, then it displays
        /// a formatted string for the searched book.
        /// This method implements "LINEAR SEARCH Algorithm".
        /// 
        /// Big-O Notation: O(n) - Linear time complexity 
        /// Due to the loop that iterates through the books dictionary.
        /// The loop runs once for each entry in the dictionary, resulting in linear time complexity.
        /// </summary>
        /// <param name="targetBookAuthor"></param>
        /// <param name="booksInLibarary"></param>
        public void SearchBookByAuthor(
            string targetBookAuthor,
            Dictionary<int, List<string>> booksInLibarary)
        {
            bool bookFound = false;
            foreach (var keyValuePair in booksInLibarary)
            {
                // Get the list of book details from the booksInLibrary dictionary
                List<string> bookDetails = keyValuePair.Value;

                // Get the author of the book from the list of book details
                string bookAuthor = bookDetails[1].ToLower();

                if (bookAuthor == targetBookAuthor)
                {
                    Console.WriteLine($"Book ID: {keyValuePair.Key}, Title: {bookDetails[0]}, Author: {bookDetails[1]}, " +
                    $"Publication year: {bookDetails[2]}, Genre: {bookDetails[3]}, Status: {bookDetails[4]}");
                    Console.WriteLine("-  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -");
                    bookFound = true;
                }
            }
            if (!bookFound)
            {
                Console.WriteLine("The book you searched of the specified author doesnot exist in the library.");
            }
        }

        /// <summary>
        /// This method takes user input ID (target) and checks if it is an integer greater than 0. Then it checks if the books
        /// dictionary contains the ID as its key. If so, then it gets the book details list from the books dictionary and displays
        /// a formatted string containing the book details.
        /// 
        /// Big-O Notation: O(1) - Constant time complexity
        /// The lookup in the dictionary is constant time.
        /// The method directly accesses the book details using the book ID as the key in the dictionary,
        /// resulting in constant time complexity.
        /// </summary>
        /// <param name="booksInLibrary"></param>
        public void SearchBookById(Dictionary<int, List<string>> booksInLibrary)
        {
            Console.WriteLine("Please enter the ID of the book: ");
            string stringTargetBookId = Console.ReadLine().Trim();
            Console.WriteLine();
            int targetBookId;

            // Prompting the user to enter the correct book ID
            while (
                !int.TryParse(stringTargetBookId, out targetBookId)
                || targetBookId <= 0)
            {
                Console.WriteLine("Invalid book ID. Please enter a valid number for the book ID.");
                Console.WriteLine();
                Console.Write("Please enter the ID of the book: ");
                stringTargetBookId = Console.ReadLine().Trim();
            }

            // Check if the target ID is there in the booksInLibrary dictionary
            if (booksInLibrary.ContainsKey(targetBookId))
            {
                List<string> bookDetails = booksInLibrary[targetBookId - 1];

                Console.WriteLine($"Book ID: {targetBookId}, Title: {bookDetails[0]}, Author: {bookDetails[1]}, " +
                $"Publication year: {bookDetails[2]}, Genre: {bookDetails[3]}, Status: {bookDetails[4]}");
                Console.WriteLine("-  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -");
            }
            else
            {
                Console.WriteLine($"The book with ID {targetBookId} doesnot exist in the library.");
            }
        }
    }
}

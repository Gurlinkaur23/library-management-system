using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class ViewBooks
    {
        /// <summary>
        /// This method gives the users a choice to view the books based on 2 criteria: view all books and view by genre.
        /// It then validates the user input. If the valiation is successful, it uses switch case and calls the
        /// corresponding methods to accomplish the task of viewing books.
        /// 
        /// Big-O Notation: O(1) -> Constant time complexity.
        /// The operations involved in presenting options and calling methods are constant time regardless
        /// of the size of input.
        /// </summary>
        /// <param name="listOfGenresAndTitles"></param>
        /// <param name="booksInLibarary"></param>
        public void OptionsToViewBooks(
            Dictionary<string, List<string>> listOfGenresAndTitles,
            Dictionary<int, List<string>> booksInLibarary)
        {
            try
            {
                bool isUserInputInCorrect = true;

                // Continue the loop until the user enters the correct input
                while (isUserInputInCorrect)
                {
                    Console.WriteLine();
                    Console.WriteLine("Choose a number from the given options to view the books:");
                    Console.WriteLine("1. View all books.");
                    Console.WriteLine("2. View books by Genre.");
                    Console.WriteLine();

                    Console.Write("Select option: ");
                    string userChoice = Console.ReadLine().Trim();
                    Console.WriteLine();

                    // Checking if the user input is an integer and within the range of the options
                    if (int.TryParse(userChoice, out int choice) && choice > 0 && choice <= 2)
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("The list of all the books is as below:");
                                Console.WriteLine();
                                ViewAllBooks(booksInLibarary);
                                break;
                            case 2:
                                ViewBooksByGenre(listOfGenresAndTitles, booksInLibarary);
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
        /// This method loops through the dictionary of books in the library and gets the list of book details.
        /// Based on the list, it nicely formats a string containing all the info and displays it for the user.
        /// 
        /// Big-O Notation: O(n) - Linear time complexity.
        /// The loop iterates through all elements in the dictionary. It depends on the number of books in the library as
        /// the time complexity is directly proportional to the number of books in the library (n).
        /// </summary>
        /// <param name="booksInLibarary"></param>
        public void ViewAllBooks(Dictionary<int, List<string>> booksInLibarary)
        {
            foreach (var keyValuePair in booksInLibarary)
            {
                // Get the list of book details from the booksInLibrary dictionary
                List<string> bookDetails = keyValuePair.Value;

                // Display the book along with the book details
                Console.WriteLine($"Book ID: {keyValuePair.Key}, Title: {bookDetails[0]}, Author: {bookDetails[1]}, " +
                $"Publication year: {bookDetails[2]}, Genre: {bookDetails[3]}, Status: {bookDetails[4]}");
                Console.WriteLine("-  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -");
            }
        }

        /// <summary>
        /// This method first presents a list of genres to the user to select. The user selects a number for the genre, which
        /// is then validated. After this, it loops through the dictionary of books, gets list of book details. Then it checks
        /// if the list of details contains the selected genre. If yes, then it displays the book.
        /// 
        /// Big-O Notation: O(n * m) - where 'n' is the number of books in the library 
        ///                            and 'm' is the average number of genres associated with each book.
        /// This method loops through the dictionary of genres and books. So, the time complexity is affected by both 
        /// the number of books and the average number of genres associated with each book. Since the number of genres is not
        /// the same as the number of books, so let's say the number of books is 'n' and number of genres is 'm'. Hence, the
        /// time complexity is O(n * m)
        /// </summary>
        /// <param name="listOfGenresAndTitles"></param>
        /// <param name="booksInLibarary"></param>
        public void ViewBooksByGenre(
            Dictionary<string, List<string>> listOfGenresAndTitles,
            Dictionary<int, List<string>> booksInLibarary)
        {
            try
            {
                Console.WriteLine("Please select a number from the list of genres as below: ");

                int index = 1;
                // Printing the list of genres
                foreach (var keyValuePair in listOfGenresAndTitles)
                {
                    Console.WriteLine($"{index}: {keyValuePair.Key}");
                    index++;
                }
                Console.WriteLine();

                bool isInputIncorrect = true;
                while (isInputIncorrect)
                {
                    Console.Write("Select option: ");
                    string userChoice = Console.ReadLine().Trim();
                    Console.WriteLine();

                    if (int.TryParse(userChoice, out int choice) && choice > 0 && choice <= listOfGenresAndTitles.Count)
                    {
                        // Get the genre from the dictionary based on the user selection
                        string userSelectedGenre = listOfGenresAndTitles.Keys.ElementAt(choice - 1);

                        Console.WriteLine($"The list of all the books in {userSelectedGenre} are as below:");
                        Console.WriteLine();

                        foreach (var keyValuePair in booksInLibarary)
                        {
                            // Get the list of book details from the booksInLibrary dictionary
                            List<string> bookDetails = keyValuePair.Value;

                            // Check if the list of details contains the genre selected by the user and only then
                            // display the book.
                            if (bookDetails.Contains(userSelectedGenre))
                            {
                                // Display the book along with the book details
                                Console.WriteLine($"Book ID: {keyValuePair.Key}, Title: {bookDetails[0]}, Author: " +
                                    $"{bookDetails[1]}, Publication year: {bookDetails[2]}, Genre: {bookDetails[3]}" +
                                    $", Status: {bookDetails[4]}");
                                Console.WriteLine("-  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -");
                            }
                        }
                        isInputIncorrect = false;
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class AddBooks
    {
        int bookId = 1;

        /// <summary>
        /// This method asks the user to input the title of the book and checks whether the input is empty or if the book
        /// with the input title already exists in the library . After validating, it returns the title.
        /// 
        /// Big O-Notation: O(n) -> Linear time complexity.
        /// The loop depends on the number of existing book titles (n).
        /// </summary>
        /// <returns>Title</returns>
        public string UserInputTitleOfBook(List<string> listOfBookTitles)
        {
            Console.Write("Enter the title of the book: ");
            string titleOfBook = Console.ReadLine().Trim();

            while (string.IsNullOrWhiteSpace(titleOfBook) || listOfBookTitles.Contains(titleOfBook))
            {
                if (string.IsNullOrWhiteSpace(titleOfBook))
                {
                    Console.WriteLine("Invalid title. Please enter a valid title of the book.");
                }
                else
                {
                    Console.WriteLine($"A book with {titleOfBook} title already exists in the library.");
                }
                Console.WriteLine();
                Console.Write("Enter the title of the book: ");
                titleOfBook = Console.ReadLine().Trim();
            }

            return titleOfBook;
        }

        /// <summary>
        /// This method asks the user to input the author of the book and checks whether the input is empty or contains
        /// a digit or a symbol. After validating, it returns the Author.
        /// 
        /// Big O-Notation: O(1) -> Constant time complexity.
        /// The author input validation check is constant time.
        /// </summary>
        /// <returns>Author</returns>
        public string UserInputAuthorOfBook()
        {
            Console.Write("Enter the author of the book: ");
            string authorOfBook = Console.ReadLine().Trim();

            while (
                string.IsNullOrWhiteSpace(authorOfBook)
                || authorOfBook.Any(char.IsDigit)
                || authorOfBook.Any(char.IsSymbol))
            {
                Console.WriteLine("Invalid author name. Please enter a valid name of the author.");
                Console.WriteLine();
                Console.Write("Enter the author of the book: ");
                authorOfBook = Console.ReadLine().Trim();
            }

            return authorOfBook;
        }

        /// <summary>
        /// This method asks the user to input the publication year of the book and checks whether the input is an integer
        /// or if the input year is negative or greater than the current year, which is 2024.
        /// After validating, it returns the publication year.
        /// 
        /// Big O-Notation: O(1) -> Constant time complexity.
        /// The publication year input validation check is constant time.
        /// </summary>
        /// <returns>Publication year</returns>
        public int UserInputPublicationYear()
        {
            int publicationYearOfBook;
            Console.Write("Enter the publication year of the book: ");
            string stringPublicationYear = Console.ReadLine().Trim();

            while (
                !int.TryParse(stringPublicationYear, out publicationYearOfBook)
                || publicationYearOfBook <= 0
                || publicationYearOfBook > 2024)
            {
                Console.WriteLine("Invalid publication year. Please enter a valid number for the publication year");
                Console.WriteLine();
                Console.Write("Enter the publication year of the book: ");
                stringPublicationYear = Console.ReadLine().Trim();
            }

            return publicationYearOfBook;
        }

        /// <summary>
        /// This method asks the user to input the genre of the book and checks whether the input is empty or contains
        /// a digit or a symbol. After validating, it returns the genre.
        /// 
        /// Big O-Notation: O(1) -> Constant time complexity.
        /// The genre input validation check is constant time.
        /// </summary>
        /// <returns>Genre</returns>
        public string UserInputGenreOfBook()
        {
            Console.Write("Enter the genre of the book: ");
            string genreOfBook = Console.ReadLine().Trim();

            while (
                string.IsNullOrWhiteSpace(genreOfBook)
                || genreOfBook.Any(char.IsDigit)
                || genreOfBook.Any(char.IsSymbol))
            {
                Console.WriteLine("Invalid genre. Please enter a valid genre of the book.");
                Console.WriteLine();
                Console.Write("Enter the genre of the book: ");
                genreOfBook = Console.ReadLine().Trim();
            }

            return genreOfBook;
        }

        /// <summary>
        /// This method calls the other input methods for the book details and adds the book to the library (dictionary).
        /// It adds titles to a separate list. It also adds genres and corresponding titles to a separate dictionary 
        /// to keep a track of titles and genres.
        /// 
        /// Big O-Notation: O(1) -> Constant time complexity.
        /// Each opeartion in this method is constant time. For example, adding book details to dictionary,
        ///  adding titles to list, adding genres and titles to dictionary are all constant time.
        /// </summary>
        /// <param name="booksInLibrary"></param>
        /// <param name="listOfBookTitles"></param>
        /// <param name="listOfGenres"></param>
        public void AddBooksToLibrary(
            Dictionary<int, List<string>> booksInLibrary,
            List<string> listOfBookTitles,
            Dictionary<string, List<string>> listOfGenresAndTitles)
        {
            // Call the input validation methods
            string titleOfBook = UserInputTitleOfBook(listOfBookTitles);
            string authorOfBook = UserInputAuthorOfBook();
            int publicationYearOfBook = UserInputPublicationYear();
            string genreOfBook = UserInputGenreOfBook();
            string statusOfBook = "Available";

            int uniqueBookId = bookId++;

            // Add the book to the library with all the details
            //booksInLibrary.Add(bookId, $" {titleOfBook}, Author: {authorOfBook}, Publication year: {publicationYearOfBook}, " +
            //    $"Genre: {genreOfBook}");
            booksInLibrary.Add(uniqueBookId, new List<string> { titleOfBook, authorOfBook, publicationYearOfBook.ToString(),
                genreOfBook, statusOfBook});

            // Add the title of the book to the list
            listOfBookTitles.Add(titleOfBook);

            // Add the genre and title of the book to the dictionary
            if (listOfGenresAndTitles.ContainsKey(genreOfBook))
            {
                // If the genre already exists in the dictionary, add the title to the corresponding genre key
                listOfGenresAndTitles[genreOfBook].Add(titleOfBook);
            }
            else
            {
                // If the genre doesnot exist in the dictionary, add the genre and a new list containing the title
                listOfGenresAndTitles.Add(genreOfBook, new List<string> { titleOfBook });
            }

            // Display a message to the user if the book is added to the library
            Console.WriteLine();
            Console.WriteLine($"The book '{titleOfBook}' is added successfully to the library with ID {uniqueBookId}.");
        }
    }
}

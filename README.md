# Library Management System

## Overview

The Library Management System is like a computerized assistant for librarians. It helps them handle various tasks related to managing books in a library. 
The system allows librarians to add new books, see what books are available, search for specific books, lend books to readers, take back borrowed books, 
and exit the system when they're done.

## Features

1. **Add a Book:** Librarians can use the system to add new books to the library.
2. **View Books:** Librarians can check what books are currently in the library. They can either view all books or view the books by genre.
3. **Search for a Book:** Librarians can find a specific book easily based on either title, author or ID.
4. **Borrow a Book:** Librarians can lend books to readers.
5. **Return a Book:** Librarians can take back books that were borrowed.
6. **Exit the Application:** Librarians can close the system when they are finished.

## How to Run

To use the Library Management System:

1. Open the application on your computer.
2. Look for the options on the screen.
3. Choose what you want to do (like add a book or view the library).
4. Follow the instructions on the screen.

## Class Files

The system is organized into different class files to keep the different functionalities separate.

1. **AddBooks.cs:** Handles the part where librarians add new books.
2. **ViewBooks.cs:** Takes care of showing librarians what books are in the library.
3. **SearchBooks.cs:** Manages the part where librarians look for specific books.
4. **BorrowAndReturnBooks.cs:** Deals with lending books to readers and taking them back.

## Design Decisions

- **Modularity:**
  <br>
I chose to split the system into different parts, like adding books or handling borrowings. This way, it's like dealing with separate pieces, making it simpler for me to
fix one thing without messing up the rest. So, if I need to make changes, I can focus on what needs attention without worrying about the whole system.

## Data Structures

The system uses certain tools to organize information:

- **Dictionary:** It's like a special list that helps keep track of all the books in the library. It stores the book ID as its key and other book details in a list as a value.
- **List:** A simple way to store details about each book.
- **Genre Dictionary:** Helps organize books by type, like fiction or non-fiction.

## Algorithms

The system follows specific steps to get things done:

- **Adding a Book:** Put the new book details in the list of books.
- **Viewing Books:** Look through the list and show each book's information.
- **Searching for a Book:** Find the book by looking through the list.
- **Borrowing a Book:** Check if the book is available and update its status. It uses Linear Search Algorithm.
- **Returning a Book:** Make sure the book was borrowed, then change its status. It uses Linear Search Algorithm.

## Challenges Faced

1. **Correct Input:**  I faced the challenge of making sure librarians enter information accurately. For this, I created separate methods to validate various inputs.
2. **Dealing with Errors:** Creating ways to handle unexpected problems in the system was also challenging for me. For this, I displayed descriptive error messages for the librarian.

## Test Cases

I thoroughly tested the application to ensure it works well in different situations. I confirmed that new books are added correctly, the list of books is displayed 
accurately, and the system can find specific books during searches. Additionally, I checked the effectiveness of the book borrowing process and verified that books 
can be successfully returned to the library. These tests assess how well the application performs in various scenarios.

## Special Instructions

- Make sure you have a working C# environment installed.
- Follow the instructions on the screen to use the system.

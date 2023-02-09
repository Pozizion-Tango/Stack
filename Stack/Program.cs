using System;
using System.Collections.Generic;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> avalible = new List<Book>();//makes a list for the books to be stored in.
            Stack<Book> borrowed = new Stack<Book>();//makes a stack for the user to keep their books.
            Book book1 = new Book("John Matt", "The Jump", 256);
            Book book2 = new Book("Hanible Not", "How To Cock Children", 15);
            Book book3 = new Book("Gabe New", "The Art Of Games", 470);
            Book book4 = new Book("Jenny Black", "Stuck", 128);
            Book book5 = new Book("Luna Fox", "My Bullies", 82);
            avalible.Add(book1);
            avalible.Add(book2);
            avalible.Add(book3);
            avalible.Add(book4);
            avalible.Add(book5);
            bool stop = false;//used to stop the program when user wishes.
            while (!stop)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Avalible Books:\r\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                int number = 1;
                foreach (Book title in avalible)//shows all books and their number
                {
                    Console.Write(number + ": ");
                    Console.WriteLine(title.Title);
                    number++;
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\r\nType Number of book you want to borrow\r\nType to select\r\n\r\n");
                Console.ResetColor();
                Console.WriteLine("View: To view borrowed books\r\nReturn: To return a book\r\nQuit: To exit the program");
                string choice = Console.ReadLine();//will be used for the user to make a choice.
                if (int.TryParse(choice, out number))//tests if the choice is either a number or a word. 
                {
                    if(number <= avalible.Count && number > 0)//if choice is a number it will go and select the book choosen
                    {
                        number--;
                        borrowed.Push(avalible[number]);//the book will be stored in the stack
                        avalible.RemoveAt(number);//and removed from the list of avalible books
                    }
                }
                else if(choice == "View"||choice == "view" && borrowed.Count > 0)//checks if it user got any books to view or not.
                {
                    Console.Clear();
                    number = 1;
                    foreach (Book book in borrowed)//shows all the books borrowed and their details
                    {
                        Console.Write(number + ": ");
                        Console.WriteLine("Title: " + book.Title+ ". " + "Author: " +book.Author +". "+"Pages: "+book.Pages+"\r\n");
                        number++;
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;//it also shows which book will be returned next
                    Console.WriteLine("Next book to be returned is ("+borrowed.Peek().Title+")\r\n\r\nPress Any Key To Go back.");
                    Console.ReadKey();
                }
                else if(choice == "Return" || choice == "return" && borrowed.Count > 0)//checks if the user got any books
                {
                    Console.Clear();
                    Console.WriteLine("("+borrowed.Peek().Title + ") Is the next book to be returned.\r\n\r\nWould you like to return it? Yes/No");
                    choice = Console.ReadLine();//user will be shown which book will be returned, and asked if they would like to return it
                    if(choice == "Yes" || choice == "yes")
                    {
                        avalible.Add(borrowed.Peek());//Gives back the book to "avalible"
                        borrowed.Pop();//removes the book from the user
                    }
                    else if (choice == "No" || choice == "no")//will just throw you back into the main menu
                    {
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Option, Press Any Key To Continue");//user pressed something that is not a choice.
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                }
                else if (choice == "Quit" || choice == "quit")//Will quit the whole program.
                {
                    stop = true;//stops the loop and quits the program.
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Option, Press Any Key To Continue");//user typed something that couldn't be used.
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }
    }
}

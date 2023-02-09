using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Stack
{
    internal class Book
    {
        private string author;
        private string title;
        private int pages;
        public string Author
        {
            get { return author; }   
            set { author = value; }  
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public int Pages
        {
            get { return pages; }
            set { pages = value; }
        }
        public Book(string author, string title, int pages)
        {
            this.Author = author;
            this.Title = title;
            this.Pages = pages;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Book
{
    public delegate string BookFunctionsDelegate(Book book);

    public class Book
    {

        public int ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }
        public Book(int iSBN, string title, string[] authors, DateTime publicationDate, decimal price)
        {
            ISBN = iSBN;
            Title = title;
            Authors = authors;
            PublicationDate = publicationDate;
            Price = price;
        }

        public override string ToString()
        {
            return $"ISBN: {ISBN}\n" +
                $"Title: {Title}\n" +
                $"Authors: {string.Join(", ", Authors)}\n" +
                $"Publication Date: {PublicationDate}\n" +
                $"Price: {Price}";
        }

    }
}

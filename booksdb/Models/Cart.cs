using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace booksdb.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem (Books books, int quantity)
        {
            CartLine line = Lines.Where(b => b.Book.BookId == books.BookId).FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = books,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Books books) => Lines.RemoveAll(x => x.Book.BookId == books.BookId);

        public virtual void Clear() => Lines.Clear();

        public decimal ComputeTotalSum() => (decimal)Lines.Sum(e => e.Book.Price * e.Quantity);
        

   

        public class CartLine
        {
            public int CartlineID { get; set; }
            public Books Book{ get; set; }

            public int Quantity { get; set; }


        }
    }
}

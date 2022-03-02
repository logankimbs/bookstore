using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();
        public virtual void AddItem(BookModel bk, int quantity)
        {
            BasketLineItem line = Items
                .Where(book => book.Book.BookID == bk.BookID)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = bk,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveItem(BookModel book)
        {
            Items.RemoveAll(x => x.Book.BookID == book.BookID);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }

        public double CalculateTotal()
        {
            double sum = 0;

            foreach (var item in Items)
            {
                sum += (item.Quantity * item.Book.Price);
            }

            return Math.Round(sum, 2);
        }
    }

    public class BasketLineItem
    {
        public int LineID { get; set; }
        public BookModel Book { get; set; }
        public int Quantity { get; set; }
    }
}

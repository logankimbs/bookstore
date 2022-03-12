using System;
using System.Linq;

namespace bookstore.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<BookModel> Books { get; }

        public void SaveBook(BookModel b);
        public void CreateBook(BookModel b);
        public void DeleteBook(BookModel b);
    }
}

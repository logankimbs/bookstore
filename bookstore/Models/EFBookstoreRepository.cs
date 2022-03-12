using System;
using System.Linq;

namespace bookstore.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookContext Context { get; set; }

        public EFBookstoreRepository(BookContext context)
        {
            Context = context;
        }

        public IQueryable<BookModel> Books => Context.Books;

        public void SaveBook(BookModel b)
        {
            Context.SaveChanges();
        }

        public void CreateBook(BookModel b)
        {
            Context.Add(b);
            Context.SaveChanges();
        }

        public void DeleteBook(BookModel b)
        {
            Context.Remove(b);
            Context.SaveChanges();
        }
    }
}

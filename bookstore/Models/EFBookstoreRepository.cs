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
    }
}

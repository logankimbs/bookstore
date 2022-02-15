using System;
using System.Linq;

namespace bookstore.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<BookModel> Books { get; }
    }
}

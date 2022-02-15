using System;
using System.Linq;

namespace bookstore.Models.ViewModels
{
    public class BookViewModel
    {
        public IQueryable<BookModel> Books { get; set; }
        public PageInformation PageInfo { get; set; }
    }
}

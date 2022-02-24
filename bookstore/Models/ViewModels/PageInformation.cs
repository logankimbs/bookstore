using System;

namespace bookstore.Models.ViewModels
{
    public class PageInformation
    {
        public int NumOfBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrrentPage { get; set; }
        public int TotalPages => (int) Math.Ceiling((double) NumOfBooks / BooksPerPage);
    }
}

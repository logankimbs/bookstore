using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using bookstore.Infrastructure;

namespace bookstore.Pages
{
    public class CartModel : PageModel
    {
        private IBookstoreRepository Repository { get; set; }

        public CartModel(IBookstoreRepository repository, Basket b)
        {
            Repository = repository;
            Basket = b;
        }

        public Basket Basket { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            BookModel project = Repository.Books
                .FirstOrDefault(book => book.BookID == bookId);
            Basket.AddItem(project, 1);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            Basket.RemoveItem(Basket.Items.First(x => x.Book.BookID == bookId).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}

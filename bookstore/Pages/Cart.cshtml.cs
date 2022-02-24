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

        public CartModel(IBookstoreRepository repository)
        {
            Repository = repository;
        }

        public Basket Basket { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            BookModel project = Repository.Books
                .FirstOrDefault(book => book.BookID == bookId);

            Basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            Basket.AddItem(project, 1);
            HttpContext.Session.SetJson("basket", Basket);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}

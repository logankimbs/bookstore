using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using bookstore.Models;

namespace bookstore.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private IBookstoreRepository Repository { get; set; }

        public CategoriesViewComponent(IBookstoreRepository repository)
        {
            Repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];

            var categories = Repository.Books
                .Select(book => book.Category)
                .Distinct()
                .OrderBy(book => book);

            return View(categories);
        }
    }
}
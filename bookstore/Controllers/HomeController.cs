using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bookstore.Models;

namespace bookstore.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository Repository;

        public HomeController(IBookstoreRepository repository)
        {
            Repository = repository;
        }

        public IActionResult Index()
        {
            var books = Repository.Books.ToList();

            return View(books);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bookstore.Models;
using bookstore.Models.ViewModels;

namespace bookstore.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository Repository;

        public HomeController(IBookstoreRepository repository)
        {
            Repository = repository;
        }

        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;
            var pageData = new BookViewModel
            {
                Books = Repository.Books
                            .OrderBy(p => p.Title)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize),
                PageInfo = new PageInformation
                {
                    NumOfProjects = Repository.Books.Count(),
                    ProjectsPerPage = pageSize,
                    CurrrentPage = pageNum
                }
            };

            return View(pageData);
        }
    }
}

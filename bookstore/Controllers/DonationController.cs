using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using bookstore.Models;

namespace bookstore.Controllers
{
    public class DonationController : Controller
    {
        private IDonationRepository Repo { get; set; }
        private Basket Basket { get; set; }

        public DonationController(IDonationRepository repository, Basket b)
        {
            Repo = repository;
            Basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Donation());
        }

        [HttpPost]
        public IActionResult Checkout(Donation donation)
        {
            if (Basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your basket is empty");
            }

            if (ModelState.IsValid)
            {
                donation.Lines = Basket.Items.ToArray();
                Repo.SaveDonation(donation);
                Basket.ClearBasket();

                return RedirectToPage("/DonationComplete");
            }
            else
            {
                return View();
            }
        }
    }
}

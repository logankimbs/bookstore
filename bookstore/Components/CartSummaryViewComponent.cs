using Microsoft.AspNetCore.Mvc;
using bookstore.Models;

namespace bookstore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket repo;

        public CartSummaryViewComponent(Basket temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            return View(repo);
        }
    }
}

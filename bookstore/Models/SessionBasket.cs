using System;
using System.Text.Json.Serialization;
using bookstore.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace bookstore.Models
{
    public class SessionBasket : Basket
    {
        public static Basket GetBasket(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();
            basket.Session = session;
            return basket;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(BookModel book, int quantity)
        {
            base.AddItem(book, quantity);
            Session.SetJson("Basket", this);
        }

        public override void RemoveItem(BookModel book)
        {
            base.RemoveItem(book);
            Session.SetJson("Basket", this);
        }

        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }

        public SessionBasket()
        {
        }
    }
}

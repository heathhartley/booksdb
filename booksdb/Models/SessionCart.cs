using booksdb.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace booksdb.Models
{
    public class SessionCart : Cart
    { // The SessionCart class subclasses the Cart class and overrides the AddItem, RemoveLine, and 
      // Clear methods so they call the base implementations and then store the updated state in the 
      // session using the extension methods on the ISession interface.
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("cart")
                ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Books book, int quantity)
        {
            base.AddItem(book, quantity);
            Session.SetJson("cart", this);
        }
        public override void RemoveLine(Books book)
        {
            base.RemoveLine(book);
            Session.SetJson("cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("cart");
        }
    }
}

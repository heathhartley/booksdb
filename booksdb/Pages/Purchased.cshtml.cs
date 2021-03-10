using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using booksdb.Infrastructure;
using booksdb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace booksdb.Pages
{
    public class PurchasedModel : PageModel
    {
        public IBookRepository repository;
        //constructor
        public PurchasedModel(IBookRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }
        // Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        // Methods
        public void OnGet(string returnUrl) // retrieves the users cart
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long BookId, string returnUrl) // sends the users cart
        {
            Books book = repository.Books.FirstOrDefault(b => b.BookId == BookId);

            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(book, 1);

            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }


        public IActionResult OnPostRemove(long BookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Book.BookId == BookId).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}


//
//

//
//
/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using  booksdb.Infrastructure;
using  booksdb.Models;

namespace OnlineBookStore.Pages
{
    public class PurchasedModel : PageModel
    {
        private IBookRepository repository;

        // Constructor for PurchaseModel
        public PurchasedModel(IBookRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        // Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        // Methods
        public void OnGet(string returnUrl) // retrieves the users cart
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long BookId, string returnUrl) // sends the users cart
        {
            Books book = repository.Books.FirstOrDefault(b => b.BookId == BookId);

            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(book, 1);

            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long BookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Book.BookId == BookId).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

    }
}*/
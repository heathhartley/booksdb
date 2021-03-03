using booksdb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using booksdb.Models.ViewModels;

namespace booksdb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBookRepository _repository;

        public int ItemsPerPage = 5;

        public HomeController(ILogger<HomeController> logger, IBookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int page=1)
        {
            return View(new BookListViewModel
            {
                Books = _repository.Books
                .Where(b => category == null || b.Category == category)
                .OrderBy(b => b.BookId)
                .Skip((page - 1) * ItemsPerPage)
                .Take(ItemsPerPage),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = ItemsPerPage,
                    TotalNumItems = category == null ? _repository.Books.Count() : _repository.Books.Where(b => b.Category == category).Count()
                },
                CurrentCategory = category
            });
                
                
                

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

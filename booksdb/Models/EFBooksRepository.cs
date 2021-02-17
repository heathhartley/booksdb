using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace booksdb.Models
{
    public class EFBooksRepository : IBookRepository
    {
        private BookDbContext _context;
        //constructor
        public EFBooksRepository (BookDbContext context)
        {
            _context = context;
        }
        public IQueryable<Books> Books => _context.Books;
       

    }
}

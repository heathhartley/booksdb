using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace booksdb.Models
{
    public interface IBookRepository
    {
        IQueryable<Books> Books { get; }
    }
}

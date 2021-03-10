using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace booksdb.Models
{
    public interface IBookRepository
    {
/*I dont know what is happening here but I dont think thats my fault.*/
        IQueryable<Books> Books { get; }
    }
}

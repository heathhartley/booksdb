using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace booksdb.Models.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Books> Books { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}

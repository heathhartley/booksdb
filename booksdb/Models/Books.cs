using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace booksdb.Models
{
    public class Books
    {
        [Key]
        [Required]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorFirst { get; set; }
        [Required]
        public string AuthorMiddle { get; set; }
        [Required]
        public string AuthorLast { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{3}(-[0-9]{10})$", ErrorMessage = "ISBN format is invalid.")] //requiered in this formate
        public string ISBN { get; set; }
        [Required]
        public string Category { get; set; } //atomic
        [Required]
        public string Classification { get; set; } //atomic
        [Required]
        public double Price { get; set; }
        [Required]
        public int PageNum { get; set; }

    }
}
/* Create a web app for an online bookstore. For each book, we want to store the following
information:
• Title
• Author
• Publisher
• ISBN
• Classification/Category
• Price
All fields are required. Use the “Model First” approach described in the videos to set up and
create the database that we will use for the app. The ISBN needs to be entered in a valid format.
Include a “BookId” field that can be used as a primary key. Use good normalization principles
(i.e. no non-atomic fields, no repeating groups).*/

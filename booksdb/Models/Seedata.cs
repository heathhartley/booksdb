using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace booksdb.Models
{
    public class Seedata
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            BookDbContext context = application.ApplicationServices.CreateScope().
                ServiceProvider.GetRequiredService<BookDbContext>();

            if(context.Database.GetPendingMigrations().Any())  
            {
                context.Database.Migrate();

            }
            if(!context.Books.Any())
            {
                context.Books.AddRange(
                    //add books to database
                    new Books
                    {
                       
                        Title = "Les Miserables",
                        AuthorFirst = "Victor",
                        AuthorMiddle = "",
                        AuthorLast = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95,
                        

                    },
                     new Books
                     {

                         Title = "Team of Rivals",
                         AuthorFirst = "Doris",
                         AuthorMiddle = "Kearns",
                         AuthorLast = "Goodwin",
                         Publisher = "Simon & Schester",
                         ISBN = "978-0743270755",
                         Classification = "Non-Fiction",
                         Category = "Biograghy",
                         Price = 14.58,


                     },
                      new Books
                      {

                          Title = "The SnowBall",
                          AuthorFirst = "Alice",
                          AuthorMiddle = "",
                          AuthorLast = "Schroeder",
                          Publisher = "Bantam",
                          ISBN = "978-0553384611",
                          Classification = "Non-Fiction",
                          Category = "Biograghy",
                          Price = 21.54,


                      },
                       new Books
                       {

                           Title = "American Ulysses",
                           AuthorFirst = "Ronald",
                           AuthorMiddle = "C.",
                           AuthorLast = "White",
                           Publisher = "Random House",
                           ISBN = "978-0812974492",
                           Classification = "Non-Fiction",
                           Category = "Biograghy",
                           Price = 11.61,


                       },
                       new Books
                       {

                           Title = "Unbroken",
                           AuthorFirst = "Laura",
                           AuthorMiddle = "",
                           AuthorLast = "Hillenbrand",
                           Publisher = "Random House",
                           ISBN = "978-0812974492",
                           Classification = "Non-Fiction",

                           Category = "Biograghy",
                           Price = 13.33,


                       },
                        new Books
                        {

                            Title = "The Great Train Robbery",
                            AuthorFirst = "Michael",
                            AuthorMiddle = "",
                            AuthorLast = "Crichton",
                            Publisher = "Vintage",
                            ISBN = "978-0804171281",
                            Classification = "Fiction",
                            Category = "Historical Fiction",
                            Price = 15.95,


                        },
                         new Books
                         {
                             Title = "Deep Work",
                             AuthorFirst = "Cal",
                             AuthorMiddle = "",
                             AuthorLast = "Newport",
                             Publisher = "Grand Central Publishing",
                             ISBN = "978-1555586691",
                             Category = "Self-Help",
                             Classification = "Non-Fiction",
                             Price = 14.99,


                         },
                          new Books
                          {

                              Title = "It's Your Ship",
                              AuthorFirst = "Michael",
                              AuthorMiddle = "",
                              AuthorLast = "Abrashoff",
                              Publisher = "Grand Central Publishing",
                              ISBN = "978 - 1455523023",
                              Classification = "Non-Fiction",
                              Category = "Self-Help",
                              Price = 21.66,


                          },
                           new Books
                           {

                               Title = "The Virgin Way",
                               AuthorFirst = "Richard",
                               AuthorMiddle = "",
                               AuthorLast = "Branson",
                               Publisher = "Portfolio",
                               ISBN = "978 - 1591847984",
                               Classification = "Non-Fiction",
                               Category = "Business",
                               Price = 29.16,


                           },
                            new Books
                            {

                                Title = "Sycamore Row",
                                AuthorFirst = "John",
                                AuthorMiddle = "",
                                AuthorLast = "Grisham",
                                Publisher = "Bantam",
                                ISBN = "978 - 0553393613",
                                Classification = "Fiction",
                                Category = "Thrillers",
                                Price = 15.03,

                            }

                    );

                context.SaveChanges();
               
            }
        }
    }
}

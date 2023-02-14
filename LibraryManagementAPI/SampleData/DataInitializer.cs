using System;
using LibraryManagementAPI.Entities;
using LibraryManagementAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagementAPI.SampleData
{
    public static class DataInitializer
    {

        public static List<Book> lstBooksSample = new List<Book>
            {
                new Book
                {
                    Authors = new List<string> {"Brian Jensen"},
                    ISBN = "123-3465-2645",
                    Title = "Texts from Denmark",
                    Publisher = "Gyldendal",
                    PublicationYear = 2001,
                    NumberOfPages = 253
                },
                new Book
                {
                    Authors = new List<string> { "Peter Jensen", "Hans Andersen" },
                    ISBN = "123-3465-2646",
                    Title = "Stories from abroad",
                    Publisher = "Borgen",
                    PublicationYear = 2012,
                    NumberOfPages = 156

                }

            };

        public static List<Book> lstSampleInventoryBooks = new List<Book>
            {
                new Book
                {
                    Authors = new List<string> {"Jack Williams"},
                    ISBN = "234-3465-2344",
                    Title = "Call of the Forest",
                    Publisher = "Times",
                    PublicationYear = 2019,
                    NumberOfPages = 200
                },
                new Book
                {
                    Authors = new List<string> { "Mark Peterson", "James Mathew" },
                    ISBN = "4564-345-2646",
                    Title = "A Spell too Far",
                    Publisher = "Square",
                    PublicationYear = 1990,
                    NumberOfPages = 100

                }

            };

        public static List<LibraryInventory> library = new List<LibraryInventory>()
        {
            new LibraryInventory
            {
                Books = lstBooksSample,
                Room = 1,
                Row= 1,
                BookShelf = 1
            },
            new LibraryInventory
            {
                Books = lstSampleInventoryBooks,
                Room = 1,
                Row= 1,
                BookShelf = 2
            }

        };

        internal static void Seed(RepositoryContext ctx)
        {
            ctx.Database.EnsureCreated();


            if (!ctx.Books.Any())
            {
                ctx.AddRange(lstBooksSample);
                ctx.SaveChanges();
            }

        }
    }
}
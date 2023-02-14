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



        internal static void Seed( RepositoryContext ctx)
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
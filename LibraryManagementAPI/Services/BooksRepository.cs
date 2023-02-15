using System;
using System.Linq.Expressions;
using LibraryManagementAPI.Entities;
using LibraryManagementAPI.Models;
using LibraryManagementAPI.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static LibraryManagementAPI.SampleData.DataInitializer;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace LibraryManagementAPI.Services
{
    public class BooksRepository : IRepositoryBase<Book>, IBooksRepository
    {
        RepositoryContext _repositoryContext;

        public BooksRepository()
        {

        }

        public BooksRepository(RepositoryContext repositoryContext) //: base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Create(Book entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Book entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Book> FindAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Book> FindByCondition(Expression<Func<Book, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(Book entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Book> FindAllColumns(string searchString)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllSampleBooks()
        {
            //return sample data
            return LibraryManagementAPI.SampleData.DataInitializer.lstBooksSample;
        }

        public List<Book> FindBooks(string searchString)
        {
            var searchResults = LibraryManagementAPI.SampleData.DataInitializer.lstBooksSample
                .Where(a => a.Authors.Any(a => a == searchString) || a.Title.Contains(searchString) ||
                a.Publisher.Contains(searchString) || Convert.ToString(a.PublicationYear).Contains(searchString));

            return searchResults.ToList();
        }

        public List<Book> FindBooksMultipleSearchCriteria(string searchString)
        {
            var searchMultipleStrings = searchString?.Split("&").ToList();

            //var searchResults = LibraryManagementAPI.SampleData.DataInitializer.lstBooksSample.All(A => searchMultipleStrings.Any(b => A.Authors.Contains(b) || A.Title.Contains(b)
            //|| Convert.ToString(A.PublicationYear).Contains(searchString) || A.Publisher.Contains(b)));

            var results = (from book in lstBooksSample
                           from j in searchMultipleStrings 
                           where book.Publisher.Contains(j) ||
                           book.PublicationYear.ToString().Contains(j) ||
                           book.Title.Contains(j) //||
                           //book.Authors.Any(a=>a == searchMultipleStrings)
                           select book).ToList();


            return results;
        }

        public List<Book> GetAllBooks()
        {
            return new List<Book>
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
                    Authors = new List<string> {"Peter Jensen" , "Hans Andersen"},
                    ISBN = "123-3465-2646",
                    Title = "Stories from abroad",
                    Publisher = "Borgen",
                    PublicationYear = 2012,
                    NumberOfPages = 156
                }
            };
        }


        ///// <summary>
        ///// Locate book in Library by its ISBN number - static sample data
        ///// </summary>
        ///// <param name="isbn"></param>
        ///// <returns></returns>
        //public LibraryInventory LocateSampleBookByISBN(string isbn)

        //{
        //    var result = (from a in library
        //                  where (a.Items.Any(b => b.ISBN == isbn))
        //                  select a).FirstOrDefault();


        //    return result;
        //}


        /// <summary>
        /// Locate book in Library by its ISBN number - static sample data
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public object LocateSampleItemByISBN(string isbn)

        {
            var result = (from a in library
                          where a.Item.ISBN == isbn
                          // group a by a.Item.ISBN into G
                          group a by new { a.Item.ISBN } into G

                          select new
                          {
                              ISBN = G.Key.ISBN,
                              //   BookShelfNumber = G.Key.BookShelf,
                              totalItems = G.Count()

                          });


            return result;
        }

        /// <summary>
        /// Get book details by ISBN number
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public Book GetBookByISBN(string isbn) => _repositoryContext.Books
               // .Include(b => b.)
               .Where(b => b.ISBN == isbn)
               .FirstOrDefault();

        /// <summary>
        /// Get book details by ISBN number
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public LibraryInventory LocateBookByISBN(string isbn) => _repositoryContext.Inventories
            .Where(b => b.Item.ISBN == isbn)
               .FirstOrDefault();

        public IEnumerable<Book> GetBooks()
        {
            return _repositoryContext.Books
                   .ToList();
        }


        public bool CreateInventory(LibraryInventory objInventory)
        {

            return true;
        }


    }
}


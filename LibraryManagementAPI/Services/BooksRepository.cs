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
            _repositoryContext =  repositoryContext;
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
                .Where(a => a.Authors.Any(a=>a == searchString) || a.Title.Contains(searchString) ||
                a.Publisher.Contains(searchString) || Convert.ToString( a.PublicationYear).Contains(searchString));

            return searchResults.ToList();
        }

        public List<Book> FindBooksMultipleSearchCriteria(string searchString)
        {
            var searchMultipleStrings= searchString?.Split("&").ToList();

            var searchResults =  LibraryManagementAPI.SampleData.DataInitializer.lstBooksSample.All(A => searchMultipleStrings.Any(b => A.Authors.Contains(b) || A.Title.Contains(b)
            || A.PublicationYear.Equals(b) || A.Publisher.Contains(b)));

            var results = (from book in lstBooksSample
                           where searchMultipleStrings.Equals( book.Publisher) ||
                           searchMultipleStrings.Equals(book.PublicationYear) ||
                           searchMultipleStrings.Equals(book.Title) ||
                           searchMultipleStrings.Equals(book.Authors.Any())
                           select book).ToList();

            //var searchResults = LibraryManagementAPI.SampleData.DataInitializer.lstBooksSample
            //    .Where(a => a.Authors.Contains(searchString) || a.Title.Contains(searchString) ||
            //    a.Publisher.Contains(searchString) || a.PublicationYear.GetValueOrDefault().Equals(searchString));

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


        public Book GetBook(string id) =>  _repositoryContext.Books
               // .Include(b => b.)
               .Where(b => b.ISBN == id)
               .FirstOrDefault();

        public IEnumerable<Book> GetBooks()
        {
            return _repositoryContext.Books
                   .ToList();
        }
    }
}


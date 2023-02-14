using System;
using LibraryManagementAPI.Models;
using LibraryManagementAPI.Services.Contracts;

namespace LibraryManagementAPI.Services
{
	public interface IBooksRepository : IRepositoryBase<Book>
	{
         List<Book> GetAllBooks();

        List<Book> GetAllSampleBooks();

        List<Book> FindBooks(string searchString);

        List<Book> FindBooksMultipleSearchCriteria(string searchString);

        LibraryInventory LocateSampleBookByISBN(string isbn);


    }
}


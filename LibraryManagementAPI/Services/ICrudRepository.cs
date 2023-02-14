using System;
using LibraryManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementAPI.Services
{
	public interface ICrudRepository
	{
        //void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAllAsync();
        IEnumerable<Book> GetBooks();
      //  Book GetBook(string id);
       // IEnumerable<Book> GetBooksByCategory(string category);
    }
}

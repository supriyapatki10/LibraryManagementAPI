using System;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using LibraryManagementAPI.Services;
using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Controllers
{
    [ApiController]
   //[ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]/[action]")]
    public class BooksController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IBooksRepository _booksRepository;

        public BooksController(ILogger<WeatherForecastController> logger, IBooksRepository booksRepository)
        {
            _logger = logger;
            _booksRepository = booksRepository;

        }

       
        [HttpGet(Name = "ReadBooks")]
       // [Route("getBook")]
        public IEnumerable<Book> Get()
        {
            return _booksRepository.GetAllBooks();
        }

       
        [HttpGet(Name = "ReadSampleBooks")]
        //[Route("getSampleBooks")]
        public IEnumerable<Book> GetSampleBooks()
        {
            return _booksRepository.GetAllSampleBooks();
        }

       
        [HttpGet(Name = "FindBooks")]
        //[Route("FindBooks")]
        public IEnumerable<Book> FindBooks(string searchText)
        {
            return _booksRepository.FindBooks(searchText);
        }


       
        //[Route("FindBooksMultipleSearchCriteria")]
        [HttpGet(Name = "FindBooksMultipleSearchCriteria")]
        public IEnumerable<Book> FindBooksMultipleSearchCriteria(string searchText)
        {
            return _booksRepository.FindBooksMultipleSearchCriteria(searchText);
        }
    }
}


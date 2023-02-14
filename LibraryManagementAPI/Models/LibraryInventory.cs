using System;
namespace LibraryManagementAPI.Models
{
	public class LibraryInventory
	{ 
		public List<Book> Books { get; set; }
		public int Room  { get; set; }
		public int Row { get; set; }
		public int BookShelf { get; set; }
	}
}


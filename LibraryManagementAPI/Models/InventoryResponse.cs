using System;
namespace LibraryManagementAPI.Models
{
	public class InventoryResponse
	{
		public InventoryResponse()
		{
		}

		public List<Item> Items { get; set; }
        public int Room { get; set; }
        public int Row { get; set; }
        public int BookShelf { get; set; }
    }
}


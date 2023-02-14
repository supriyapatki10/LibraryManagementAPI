using System;
namespace LibraryManagementAPI.Models
{
	public class Book : Item
	{
        public List<string>? Authors { get; set; }
		public string Publisher { get; set; } = string.Empty;
        public int? PublicationYear { get; set; }
        public int? NumberOfPages { get; set; }
    }
}


using System;
namespace LibraryManagementAPI.Models
{
	public class Disc : Item
	{
		public Disc()
		{
		}

		public List<Track> lstTracks { get; set; } = new List<Track>();
	}
}


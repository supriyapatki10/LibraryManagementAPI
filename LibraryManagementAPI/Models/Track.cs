using System;
using LibraryManagementAPI.Models.Enums;

namespace LibraryManagementAPI.Models
{
	public class Track
	{
		public string Title { get; set; } = string.Empty;
		public int Duration { get; set; } = 0;
		public Artist Artist { get; set; } = new Artist();
		public TrackType Type { get; set; }
	}
}


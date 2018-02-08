using System;

namespace Blog.Common
{
	public class Comment
	{
		public int Id { get; set; }

		public string Author { get; set; }

		public string Text { get; set; }

		public DateTime PublicationDate { get; set; }

		public Post Post { get; set; }
	}
}

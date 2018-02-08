using System;
using System.Collections.Generic;

namespace Blog.Common
{
	public class Post
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Text { get; set; }

		public string Author { get; set; }

		public DateTime PostingDate { get; set; }

		public List<Comment> Comments { get; set; }
	}
}

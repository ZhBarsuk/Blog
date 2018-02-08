using System;
using System.Collections.Generic;

namespace Blog.DataAccess.Model
{
	public class Post : IEntity
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Text { get; set; }

		public string Author { get; set; }

		public DateTime PostingDate { get; set; }

		public virtual List<Comment> Comments { get; set; }
	}
}

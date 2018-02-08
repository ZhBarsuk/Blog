using System;

namespace Blog.DataAccess.Model
{
	public class Comment : IEntity
	{
		public int Id { get; set; }

		public string Author { get; set; }

		public string Text { get; set; }

		public DateTime PublicationDate { get; set; }

		public int PostId { get; set; }

		public virtual Post Post { get; set; }
	}
}

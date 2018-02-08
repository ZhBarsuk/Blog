using System;
using Blog.Common;

namespace Blog.Services.Validation
{
	public class PostValidator : IPostValidator
	{
		public bool Validate(Post post)
		{
			return !string.IsNullOrEmpty(post.Title) &&
				!string.IsNullOrEmpty(post.Author) &&
				!string.IsNullOrEmpty(post.Text) &&
				DateTime.MinValue != post.PostingDate;
		}
	}
}
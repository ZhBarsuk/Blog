using Blog.DataAccess.Model;

namespace Blog.DataAccess
{
	public class CommentRepository : Repository<Comment>
	{
		public CommentRepository(BlogContext context) : base(context)
		{
		}
	}
}
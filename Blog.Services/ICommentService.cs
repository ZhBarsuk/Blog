using System.Threading.Tasks;
using Blog.Common;

namespace Blog.Services
{
	public interface ICommentService
	{
		Comment Add(Comment comment, int postId);

		Task<Comment> AddAsync(Comment comment, int postId);

		Comment Get(int id);

		Task<Comment> GetAsync(int id);

		Comment Update(Comment comment);

		Task<Comment> UpdateAsync(Comment comment);

		void Delete(int id);

		Task DeleteAsync(int id);
	}
}
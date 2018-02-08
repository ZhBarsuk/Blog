using System.Linq;
using System.Threading.Tasks;
using Blog.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace Blog.DataAccess
{
	public class PostRepository : Repository<Post>
	{
		public PostRepository(BlogContext context) : base(context)
		{
			
		}

		public override Post Get(int id)
		{
			return Context.Set<Post>().Include(x => x.Comments).FirstOrDefault(x => x.Id == id);
		}

		public override Task<Post> GetAsync(int id)
		{
			return Context.Set<Post>().Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id); ;
		}
	}
}

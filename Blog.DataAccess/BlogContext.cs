using Blog.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace Blog.DataAccess
{
	public class BlogContext : DbContext
	{
		public BlogContext(DbContextOptions<BlogContext> options) : base(options)
		{
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Post>().HasKey(x => x.Id);

			modelBuilder.Entity<Comment>().HasKey(x => x.Id);

			modelBuilder.Entity<Comment>().HasOne(x => x.Post).WithMany(x => x.Comments).HasForeignKey(x => x.PostId);
		}
	}
}

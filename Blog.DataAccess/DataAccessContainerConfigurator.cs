using System;
using System.Collections.Generic;
using System.Text;
using Blog.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Post = Blog.DataAccess.Model.Post;

namespace Blog.DataAccess
{
	public class DataAccessContainerConfigurator : IConfigurator 
	{
		public IServiceCollection ConfigureContainer(IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<BlogContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
			services.AddTransient<IRepository<Post>, PostRepository>();
			return services;
		}
	}
}

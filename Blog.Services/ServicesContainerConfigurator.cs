using AutoMapper;
using Blog.Common;
using Blog.Services.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Services
{
	public class ServicesContainerConfigurator : IConfigurator
	{
		public IServiceCollection ConfigureContainer(IServiceCollection services, IConfiguration configuration)
		{
			services.AddTransient<IPostService, PostService>();
			services.AddTransient<IMapper>(x => ConfugureMapper());
			services.AddSingleton<IPostValidator, PostValidator>();
			return services;
		}

		private Mapper ConfugureMapper()
		{
			MapperConfiguration configuration = new MapperConfiguration(config =>
			{
				config.CreateMap<Post, DataAccess.Model.Post>();
				config.CreateMap<Comment, DataAccess.Model.Comment>();
			});
			return new Mapper(configuration);
		}
	}
}

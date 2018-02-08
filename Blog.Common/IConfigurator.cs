using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Common
{
	public interface IConfigurator
	{
		IServiceCollection ConfigureContainer(IServiceCollection services, IConfiguration configuration);
	}
}
using Blog.Common;

namespace Blog.Services.Validation
{
	public interface IPostValidator
	{
		bool Validate(Post post);
	}
}
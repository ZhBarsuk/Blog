using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Common;

namespace Blog.Services
{
	public interface IPostService
	{
		Post Add(Post post);

		Task<Post> AddAsync(Post post);

		List<Post> Get();

		Task<List<Post>> GetAsync();

		Post Get(int id);

		Task<Post> GetAsync(int id);

		Post Update(Post post);

		Task<Post> UpdateAsync(Post post);

		void Delete(int id);

		Task DeleteAsync(int id);
	}
}
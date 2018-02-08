using System.Threading.Tasks;
using Blog.Common;
using Blog.Services;
using Microsoft.AspNetCore.Mvc;
using Blog.Api.Helpers;

namespace Blog.Api.Controllers
{
	[Route("api/[controller]")]
	public class PostsController : Controller
	{
		private readonly IPostService _postService;
		
		public PostsController(IPostService postService)
		{
			_postService = postService;
		}

		// GET: api/<controller>
		[HttpGet]
		public Task<IActionResult> Get()
		{
			return this.SaveInvokeAsync(() => _postService.GetAsync());
		}

		// GET api/<controller>/5
		[HttpGet("{id}")]
		public Task<IActionResult> Get(int id)
		{
			return this.SaveInvokeAsync(() => _postService.GetAsync(id));
		}

		// POST api/<controller>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody]Post post)
		{
			if (!ModelState.IsValid)
				return BadRequest();
			return await this.SaveInvokeAsync(() => _postService.AddAsync(post));
		}

		// PUT api/<controller>
		[HttpPut]
		public Task<IActionResult> Put([FromBody]Post post)
		{
			return this.SaveInvokeAsync(() => _postService.UpdateAsync(post));
		}

		// DELETE api/<controller>/5
		[HttpDelete("{id}")]
		public Task<IActionResult> Delete(int id)
		{
			return this.SaveInvokeAsync(() => _postService.DeleteAsync(id));
		}
	}
}

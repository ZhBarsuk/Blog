using System.Threading.Tasks;
using Blog.Api.Helpers;
using Blog.Common;
using Blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/Comments")]
	public class CommentsController : Controller
	{
		// GET: api/Comments
		private readonly ICommentService _commentService;

		public CommentsController(ICommentService commentService)
		{
			_commentService = commentService;
		}

		// GET api/<controller>/5
		[HttpGet("{id}")]
		public Task<IActionResult> Get(int id)
		{
			return this.SaveInvokeAsync(() => _commentService.GetAsync(id));
		}

		// POST api/<controller>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody]Comment comment, int postId)
		{
			if (!ModelState.IsValid)
				return BadRequest();
			return await this.SaveInvokeAsync(() => _commentService.AddAsync(comment, postId));
		}

		// PUT api/<controller>
		[HttpPut]
		public Task<IActionResult> Put([FromBody]Comment comment)
		{
			return this.SaveInvokeAsync(() => _commentService.UpdateAsync(comment));
		}

		// DELETE api/<controller>/5
		[HttpDelete("{id}")]
		public Task<IActionResult> Delete(int id)
		{
			return this.SaveInvokeAsync(() => _commentService.DeleteAsync(id));
		}
	}
}

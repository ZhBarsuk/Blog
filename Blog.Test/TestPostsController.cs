using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Api.Controllers;
using Blog.Common;
using Blog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace Blog.Test
{
	[TestClass]
	public class TestPostsController
	{
		private List<Post> _testData;

		[TestInitialize]
		public void Initialize()
		{
			_testData = new List<Post>
				{
					new Post
					{
						Id = 1,
						PostingDate = new DateTime(2012, 1, 1),
						Author = "TestAuthor1",
						Text = "TestText1",
						Title = "TestTitle1"
					},
					new Post
					{
						Id = 2,
						PostingDate = new DateTime(2012, 1, 1),
						Author = "TestAuthor2",
						Text = "TestText2",
						Title = "TestTitle2"
					}
				};
		}

		[TestMethod]
		public void Get_ShouldReturnAllPosts()
		{
			PostsController controller = Setup(_testData);
			OkObjectResult result = controller.Get().Result as OkObjectResult;
			Assert.IsNotNull(result);
			List<Post> posts = result.Value as List<Post>;
			Assert.IsNotNull(posts);
			Assert.AreEqual(_testData.Count, posts.Count);
		}

		[TestMethod]
		public void Delete_ShouldDecreasePostsQty()
		{
			PostsController controller = Setup(_testData);
			OkResult result = controller.Delete(1).Result as OkResult;
			Assert.IsNotNull(result);
			Assert.AreEqual(_testData.Count, 1);
		}

		private PostsController Setup(List<Post> data)
		{
			Mock<IPostService> postsService = new Mock<IPostService>();
			postsService.Setup(x => x.GetAsync()).
				ReturnsAsync(data);

			postsService.Setup(x => x.DeleteAsync(It.IsAny<int>())).
				Returns((int id) =>
				{
					data.RemoveAll(x => x.Id == id);
					return Task.CompletedTask;
				});
			return new PostsController(postsService.Object);
		}
	}
}

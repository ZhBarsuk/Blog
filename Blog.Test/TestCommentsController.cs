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
	public class TestCommentsController
	{
		private List<Comment> _testData;

		[TestInitialize]
		public void Initialize()
		{
			_testData = new List<Comment>
				{
					new Comment
					{
						Id = 1,
						PublicationDate = new DateTime(2012, 1, 1),
						Author = "TestAuthor1",
						Text = "TestText1",
					},

					new Comment
					{
						Id = 2,
						PublicationDate = new DateTime(2012, 1, 1),
						Author = "TestAuthor2",
						Text = "TestText2"
					}
				};
		}

		[TestMethod]
		public void Post_ShouldAddComment()
		{
			CommentsController controller = Setup(_testData);

			OkObjectResult result = controller.Post(new Comment
			{
				Author = "newAuthor",
				PublicationDate = new DateTime(2012, 1, 1),
				Text = "newText"
			}, 0).Result as OkObjectResult;

			Assert.IsNotNull(result);
			Comment comment = result.Value as Comment;
			Assert.IsNotNull(comment);
			Assert.AreEqual(comment.Text, "newText");
		}

		[TestMethod]
		public void Put_ShouldUpdateComment()
		{
			CommentsController controller = Setup(_testData);
			OkObjectResult result = controller.Put(new Comment
			{
				Id = 1,
				Author = "newAuthor",
				PublicationDate = new DateTime(2012, 1, 1),
				Text = "newText"
			}).Result as OkObjectResult;

			Assert.IsNotNull(result);
			Comment comment = result.Value as Comment;
			Assert.IsNotNull(comment);
			Assert.AreEqual(comment.Text, "newText");
		}

		private CommentsController Setup(List<Comment> data)
		{
			Mock<ICommentService> postsService = new Mock<ICommentService>();
			postsService.Setup(x => x.AddAsync(It.IsAny<Comment>(), It.IsAny<int>()))
				.ReturnsAsync((Comment comment, int id) =>
				{
					data.Add(comment);
					return comment;
				});

			postsService.Setup(x => x.UpdateAsync(It.IsAny<Comment>())).
				ReturnsAsync((Comment comment) =>
				{
					Comment oldComment = data.FirstOrDefault(x => comment.Id == x.Id);
					oldComment.Author = comment.Author;
					oldComment.PublicationDate = comment.PublicationDate;
					oldComment.Text = comment.Text;
					return oldComment;
				});
			return new CommentsController(postsService.Object);
		}
	}
}
using AutoMapper;
using Blog.Common;

namespace Blog.Services.Helpers
{
	public static class MappingHelper
	{
		public static void CommentDtoToModel(IMappingOperationOptions<Comment, DataAccess.Model.Comment> option, int postId)
		{
			option.AfterMap((src, dest) => dest.PostId = postId);
		}
	}
}
using System.Threading.Tasks;
using AutoMapper;
using Blog.Common;
using Blog.DataAccess;
using Blog.Services.Helpers;

namespace Blog.Services
{
	public class CommentService : ICommentService
	{
		private readonly IRepository<DataAccess.Model.Comment> _repository;
		private readonly IMapper _mapper;

		public CommentService(IRepository<DataAccess.Model.Comment> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public Comment Add(Comment comment, int postId)
		{
			DataAccess.Model.Comment newComment = 
				_repository.Add(_mapper.Map<Comment, DataAccess.Model.Comment>(comment, opt => MappingHelper.CommentDtoToModel(opt, postId)));
			_repository.Save();
			return _mapper.Map<Comment>(newComment);
		}

		public async Task<Comment> AddAsync(Comment comment, int postId)
		{
			DataAccess.Model.Comment newComment = await _repository.AddAsync(_mapper.Map<Comment, DataAccess.Model.Comment>(comment, opt => MappingHelper.CommentDtoToModel(opt, postId)));
			await _repository.SaveAsync();
			return _mapper.Map<Comment>(newComment);
		}

		public Comment Get(int id)
		{
			return _mapper.Map<Comment>(_repository.Get(id));
		}
		public async Task<Comment> GetAsync(int id)
		{
			DataAccess.Model.Comment comment = await _repository.GetAsync(id);
			return _mapper.Map<Comment>(comment);
		}

		public Comment Update(Comment comment)
		{
			DataAccess.Model.Comment updatedComment = _repository.Update(_mapper.Map<DataAccess.Model.Comment>(comment));
			_repository.Save();
			return _mapper.Map<Comment>(updatedComment);
		}

		public async Task<Comment> UpdateAsync(Comment comment)
		{
			DataAccess.Model.Comment updatedComment = await Task.Run(() => _repository.Update(_mapper.Map<DataAccess.Model.Comment>(comment)));
			await _repository.SaveAsync();
			return _mapper.Map<Comment>(updatedComment);
		}

		public void Delete(int id)
		{
			_repository.Delete(id);
			_repository.Save();
		}

		public async Task DeleteAsync(int id)
		{
			await Task.Run(() => _repository.Delete(id));
			await _repository.SaveAsync();
		}
	}
}
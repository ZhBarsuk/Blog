using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Common;
using Blog.Common.Exceptions;
using Blog.DataAccess;
using Blog.Services.Validation;
using Microsoft.EntityFrameworkCore;

namespace Blog.Services
{
	public class PostService : IPostService
	{
		private readonly IRepository<DataAccess.Model.Post> _repository;
		private readonly IMapper _mapper;
		private readonly IPostValidator _validator;

		public PostService(IRepository<DataAccess.Model.Post> repository, IMapper mapper, IPostValidator validator)
		{
			_repository = repository;
			_mapper = mapper;
			_validator = validator;
		}

		public Post Add(Post post)
		{
			if (!_validator.Validate(post))
				throw new ValidationFailedException();
			DataAccess.Model.Post newPost = _repository.Add(_mapper.Map<DataAccess.Model.Post>(post));
			_repository.Save();
			return _mapper.Map<Post>(newPost);
		}

		public async Task<Post> AddAsync(Post post)
		{
			if (!_validator.Validate(post))
				throw new ValidationFailedException();
			DataAccess.Model.Post newPost = await _repository.AddAsync(_mapper.Map<DataAccess.Model.Post>(post));
			await _repository.SaveAsync();
			return _mapper.Map<Post>(newPost);
		}

		public Post Get(int id)
		{
			return _mapper.Map<Post>(_repository.Get(id));
		}

		public List<Post> Get()
		{
			return _repository.Query().Select(x => _mapper.Map<Post>(x)).ToList();
		}

		public Task<List<Post>> GetAsync()
		{
			return _repository.Query().Select(x => _mapper.Map<Post>(x)).ToListAsync();
		}

		public async Task<Post> GetAsync(int id)
		{
			DataAccess.Model.Post post = await _repository.GetAsync(id);
			return _mapper.Map<Post>(post);
		}

		public Post Update(Post post)
		{
			if (!_validator.Validate(post))
				throw new ValidationFailedException();
			DataAccess.Model.Post updatedPost = _repository.Update(_mapper.Map<DataAccess.Model.Post>(post));
			_repository.Save();
			return _mapper.Map<Post>(updatedPost);
		}

		public async Task<Post> UpdateAsync(Post post)
		{
			if (!_validator.Validate(post))
				throw new ValidationFailedException();
			DataAccess.Model.Post updatedPost = await Task.Run(() => _repository.Update(_mapper.Map<DataAccess.Model.Post>(post)));
			await _repository.SaveAsync();
			return _mapper.Map<Post>(updatedPost);
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
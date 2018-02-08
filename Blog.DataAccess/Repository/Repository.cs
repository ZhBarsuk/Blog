using System.Linq;
using System.Threading.Tasks;
using Blog.DataAccess.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Blog.DataAccess
{
	public abstract class Repository<T> : IRepository<T> where T : class, IEntity
	{
		protected readonly BlogContext Context;

		protected Repository(BlogContext context)
		{
			Context = context;
		}

		public virtual T Get(int id)
		{
			return Context.Set<T>().Find(id);
		}

		public virtual Task<T> GetAsync(int id)
		{
			return Context.Set<T>().FindAsync();
		}

		public T Update(T entity)
		{
			EntityEntry<T> entry = Context.Set<T>().Update(entity);
			return entry.Entity;
		}

		public void Delete(int id)
		{
			Context.Set<T>().Remove(Context.Find<T>(id));
		}

		public T Add(T entity)
		{
			return Context.Set<T>().Add(entity).Entity;
		}

		public async Task<T> AddAsync(T entity)
		{
			EntityEntry<T> entry = await Context.Set<T>().AddAsync(entity);
			return entry.Entity;
		}

		public IQueryable<T> Query()
		{
			return Context.Set<T>();
		}

		public void Save()
		{
			Context.SaveChanges();
		}

		public Task SaveAsync()
		{
			return Context.SaveChangesAsync();
		}
	}
}

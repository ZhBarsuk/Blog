using System.Linq;
using System.Threading.Tasks;
using Blog.DataAccess.Model;

namespace Blog.DataAccess
{
	public interface IRepository<T> where T : class, IEntity
	{
		T Get(int id);

		Task<T> GetAsync(int id);

		T Update(T entity);

		void Delete(int id);

		T Add(T entity);
		Task<T> AddAsync(T entity);

		IQueryable<T> Query();

		void  Save();

		Task SaveAsync();
	}
}
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace NGen
{
	public interface IDatabase<TEntity> where TEntity : BaseEntity
	{
		Task<List<TEntity>> GetListAsync();
		Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);
		Task InsertAsync(TEntity predicate);
		Task<TEntity> FirstOrDefaultAsync();
		Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
	}

	public class Database
	{
		private readonly HttpContext HttpContext;
		public Database(IHttpContextAccessor httpContext)
		{
			HttpContext = httpContext.HttpContext;
		}
		public IDatabase<TEntity> Of<TEntity>() where TEntity : BaseEntity
		{
			return HttpContext.RequestServices.GetService<IDatabase<TEntity>>();
		}
	}
}

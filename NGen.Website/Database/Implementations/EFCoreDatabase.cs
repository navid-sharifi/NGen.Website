using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace NGen
{
	public class EFCoreDatabase<TEntity> : IDatabase<TEntity> where TEntity : BaseEntity
	{
		protected readonly EfCoreDbContext DbContext;
		public DbSet<TEntity> Entities { get; set; }
		public virtual IQueryable<TEntity> Table => Entities;
		public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();
		public EFCoreDatabase(EfCoreDbContext dbContext)
		{
			DbContext = dbContext;
			Entities = DbContext.Set<TEntity>();
		}

		public Task<List<TEntity>> GetListAsync()
		{
			return TableNoTracking.ToListAsync();
		}

		public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return TableNoTracking.Where(predicate).ToListAsync();
		}

		public async Task InsertAsync(TEntity predicate)
		{
			await Entities.AddAsync(predicate);
			await DbContext.SaveChangesAsync();
		}
		
		public Task<TEntity> FirstOrDefaultAsync() => TableNoTracking.FirstOrDefaultAsync();
		public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) => TableNoTracking.Where(predicate).FirstOrDefaultAsync();

	}
}

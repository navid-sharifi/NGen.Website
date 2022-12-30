using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace NGen
{
	public class EfCoreDbContext : DbContext
	{
		public EfCoreDbContext(DbContextOptions<EfCoreDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			var assembliesFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory);
			
			foreach (var file in assembliesFiles.Where(c => c.EndsWith(".dll")))
			{
				var assemblies = Assembly.LoadFrom(file);
				var types = assemblies.GetExportedTypes()
							 .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && typeof(BaseEntity).IsAssignableFrom(c));

				foreach (var type in types)
					modelBuilder.Entity(type);

			}
		}
	}
}

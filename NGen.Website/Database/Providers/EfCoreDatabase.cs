using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.AccessControl;

namespace NGen.Website
{
	public class EfCoreDatabase : DbContext
	{
		public EfCoreDatabase(DbContextOptions<EfCoreDatabase> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			var dfd =  System.IO.Directory.GetFiles("");


			//var types = assemblies.SelectMany(a => a.GetExportedTypes())
			//			 .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && typeof(BaseType).IsAssignableFrom(c));


			//foreach (var type in types)
			//	modelBuilder.Entity(type);


		}

	}
}

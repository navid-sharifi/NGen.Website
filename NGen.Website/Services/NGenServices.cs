using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NGen.Website;

namespace NGen
{
	public static class NGenServices
	{
		public static IConfiguration Configuration
		{
			get
			{
				if (_configuration is null)
				{
					var builder = new ConfigurationBuilder()
								  .SetBasePath(Directory.GetCurrentDirectory())
								  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
								  .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

					_configuration = builder.Build();
				}
				return _configuration;

			}
		}
		private static IConfiguration _configuration;


		public static void AddNGenServices(this IServiceCollection services)
		{
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddDbContext<EfCoreDatabase>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
		}

	}
}

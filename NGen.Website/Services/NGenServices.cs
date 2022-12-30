using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NGen.Website;
using System.Diagnostics;

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

		public static void AddNGenServices(this IServiceCollection services , string[] args)
		{
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			services.AddDbContext<EfCoreDatabase>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			CreateDbIfNotExists(args);
			
		}

		private static void CreateDbIfNotExists(string[] args)
		{
			var host =  Host.CreateDefaultBuilder(args).Build();
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{
					var context = services.GetRequiredService<EfCoreDatabase>();
					context.Database.EnsureCreated();
				}
				catch (Exception ex)
				{
					var logger = services.GetRequiredService<ILogger>();
					logger.LogError(ex, "An error occurred creating the DB.");
				}
			}
		}


	}

}

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace NGen
{
	public abstract class BaseEntity
	{
		protected static Database Database
		{
			get
			{
				return new HttpContextAccessor().HttpContext.RequestServices.GetRequiredService<Database>();
			}
		}
	
		public Guid Id { get; set; }

		public BaseEntity()
		{
			if (Id == Guid.Empty)
				Id = Guid.NewGuid();
		}
	}
}

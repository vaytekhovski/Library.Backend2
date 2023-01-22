using System;
using Library.App.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Library.Persistence
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPersistence(this IServiceCollection services,
             IConfiguration configuration)
		{
			//services.AddDbContext<AuthorsDbContext>(options =>
			//{
			//	//options.UseSqlite(connectionString);

   //         });
			//services.AddScoped<IAuthorDbContext>(provider => provider.GetService<AuthorsDbContext>());
			return services;
		}
	}
}


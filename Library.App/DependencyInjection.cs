using System;
using System.Reflection;
using Library.App.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Library.App.Common.Behaviors;

namespace Library.App
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddMediatR(Assembly.GetExecutingAssembly());
			//services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
			//services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
			return services;
		}
	}
}


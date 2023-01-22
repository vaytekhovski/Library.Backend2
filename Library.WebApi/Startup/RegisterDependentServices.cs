using System;
using System.Reflection;
using Library.App;
using Library.App.Common.Mapping;
using Library.App.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Library.WebApi.Startup
{
    public static class RegisterDependentServices { 

        public static IConfiguration? Configuration { get; }

        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            });

            var settings = builder.Configuration.GetSection(nameof(MongoDBSettings));
            builder.Services.Configure<MongoDBSettings>(settings);
            builder.Services.AddSingleton<IMongoDBSettings>(ms => ms.GetRequiredService<IOptions<MongoDBSettings>>().Value);
            var connectionString = settings.GetValue<string>(nameof(MongoDBSettings.ConnectionString));
            builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(connectionString));

            builder.Services.AddApplication();
            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            builder.Services.AddSwaggerGen();

            return builder;
        }
    }
}


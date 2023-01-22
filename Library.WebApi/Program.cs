using Library.WebApi.Startup;

var builder = WebApplication.CreateBuilder(args);

WebApplication app = WebApplication.CreateBuilder(args)
    .RegisterServices()
    .Build();

app.SetupMiddleware()
    .Run();
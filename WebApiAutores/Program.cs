using WebApiAutores;

var builder = WebApplication.CreateBuilder(args);

var startUp = new StartUp(builder.Configuration);

// Add services to the container.
startUp.ConfigureServices(builder.Services);

var app = builder.Build();

startUp.Configure(app, app.Environment);

app.Run();

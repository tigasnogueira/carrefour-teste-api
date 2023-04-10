using Carrefour.Mvc.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentityConfiguration();
builder.Services.AddMvcConfiguration(builder.Configuration);
builder.Services.RegisterServices();


var app = builder.Build();

app.UseMvcConfiguration();
app.Run();
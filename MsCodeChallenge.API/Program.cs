using Microsoft.EntityFrameworkCore;
using MsCodeChallenge.API.Context;
using MsCodeChallenge.API.Repository;
using MsCodeChallenge.API.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new() { Title = "SalesCartAPI", Version = "v1" });
    c.EnableAnnotations();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services) {
    services.AddTransient<IProductsService, ProductsService>();
    services.AddHttpClient<IProductsService, ProductsService>();
    services.AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));
    services.AddTransient<IProductsRepository, ProductsRepository>();
}

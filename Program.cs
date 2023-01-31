using API_LojaVirtual.Data;
using API_LojaVirtual.Repositories;
using API_LojaVirtual.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
ConfigureMvc(builder);
ConfigureServices(builder);

var app = builder.Build();

app.MapControllers();

app.Run();

void ConfigureMvc(WebApplicationBuilder builder)
{
    builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    })
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
    }); ;
}

void ConfigureServices(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<LojaDataContext>(
        options =>
            options.UseSqlServer(connectionString));

    builder.Services.AddScoped<CategoriaRepositorio>();
    builder.Services.AddScoped<CategoriaService>();
    builder.Services.AddScoped<ProdutoRepositorio>();
    builder.Services.AddScoped<ProdutoService>();
    
}



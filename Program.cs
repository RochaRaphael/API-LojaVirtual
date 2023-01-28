


using API_LojaVirtual.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder);
//ConfigureMvc(builder);

var app = builder.Build();



app.Run();

void ConfigureServices(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<LojaDataContext>(
        options =>
            options.UseSqlServer(connectionString));
}

//void ConfigureMvc(WebApplicationBuilder builder)
//{
//    builder.Services.AddControllers()
//    .ConfigureApiBehaviorOptions(options =>
//    {
//        options.SuppressModelStateInvalidFilter = true;
//    });
//}
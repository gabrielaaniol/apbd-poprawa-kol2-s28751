using Microsoft.EntityFrameworkCore;
using pop2kolokwium.Data;
using pop2kolokwium.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
//builder.Services.AddScoped<IDbService, DbService>();

var app = builder.Build();

app.UseAuthorization();     
app.MapControllers();       
app.Run();                  
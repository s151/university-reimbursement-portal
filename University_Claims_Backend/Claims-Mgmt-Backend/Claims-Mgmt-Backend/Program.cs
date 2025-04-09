using Claims_Mgmt_Backend.Models;
using Claims_Mgmt_Backend.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<claimsdbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("Constr")));

builder.Services.RegisterService();

builder.Services.AddCors(options=>options.AddPolicy("MyPolicy",build=>
{
    build.AllowAnyOrigin();
    build.AllowAnyHeader();
    build.AllowAnyMethod();
}));

builder.Services.ConfigureJWT(builder.Configuration["JwtSecretKey"]);

//var dbconfig = new DbConfig();

//builder.Configuration.GetSection("DbConfig").Bind(dbconfig);

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.SwaggerConfigure();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("MyPolicy");

app.MapControllers();
app.UseStaticFiles();

app.Run();

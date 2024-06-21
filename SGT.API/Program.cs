using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using SGT.Application;
using SGT.Infrasturcture;
using SGT.Persistence;
using SGT.Persistence.Context;
using System.Text;
using Serilog.Core;
using Serilog.Sinks.PostgreSQL;
using SGT.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom Service Registration
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

// Loglama

//Logger Log = new LoggerConfiguration()
//    .WriteTo.Console()
//    .WriteTo.File("logs/log.txt")
//    .WriteTo.PostgreSQL(builder.Configuration.GetConnectionString("PostgreSQL"), "logs", needAutoCreateTable:true,
//        columnOptions: new Dictionary<string, ColumnWriterBase>
//        {

//        })
//    .CreateLogger();

//builder.Host.UseSerilog();



// Token doğrulama

builder.Services.AddAuthentication("Admin")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true, //Oluşturulacak token değerini kimlerin/hangi originlerin/sitelerin kullanıyı belirlediğimiz değerdir. 
            ValidateIssuer = true, //Oluşturulacak token değerini kimin dağıttığını ifade edeceğimiz alandır. 
            ValidateLifetime = true, //Oluşturulan token değerinin süresini kontrol edecek olan doğrulamadır.
            ValidateIssuerSigningKey = true, //Üretilecek token değerinin uygulamamıza ait bir değer olduğunu ifade eden security key verisinin doğrulanmasıdır.
            ValidAudience = builder.Configuration["Token:Audience"], 
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


// Global Exception Handler
app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    // Bloglar için slug tabanlı routing
    endpoints.MapControllerRoute(
        name: "blog",
        pattern: "blog/{slug}",
        defaults: new { controller = "Blog", action = "Details" });
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<SGT_APIDbContext>();
    context.Database.Migrate();
}


app.Run();

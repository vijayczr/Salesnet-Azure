using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SalesCustom.Services;
using SalesNet.DapperContext;
using SalesNet.DataEntities;
using SalesNet.Helpers;
using SalesNet.Services;
using System.Configuration;
using static SalesCustom.Services.IAuthenticationService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AdventureContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"), options => { options.EnableRetryOnFailure(); });
});
builder.Services.AddControllers(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

// Add services to the container.
builder.Services.AddScoped<IAuthenticationService , Login>();
builder.Services.AddScoped<IHrmanualService, HrManual>();
builder.Services.AddScoped<IHolidaysService, Holidays>();
builder.Services.AddScoped<IKnowledgeShareService, KNowledgeShare>();
builder.Services.AddScoped<IDarService, Dar>();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddScoped<DapperContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
ILoggerFactory loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
string logPath = Path.Combine(Directory.GetCurrentDirectory(), "_Logs/log.txt");
if (Directory.Exists(logPath))
    Directory.CreateDirectory(logPath);
loggerFactory.AddFile(Path.Combine(logPath));
app.UseHttpsRedirection();
app.UseRouting();

/* Global cors policy */
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

    app.UseAuthorization();
app.UseMiddleware<JwtMiddleware>();
app.UseEndpoints(x => x.MapControllers());
app.MapControllers();

app.Run();

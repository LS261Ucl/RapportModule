using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Rapport.BusinessLogig.Interfaces;
using Rapport.BusinessLogig.Services;
using Rapport.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add in to Sqlserver in cloud       
builder.Services.AddDbContext<ReportDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReportConnection"));

});

//add in to localserver

// Add in to localdb 
//builder.Services.AddDbContext<ReportDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

//});

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

//Services
builder.Services.AddScoped<ITemplateService, TemplateService>();
builder.Services.AddScoped<ITemplateGroupService, TemplateGroupService>();
builder.Services.AddScoped<ITemplateElementService, TemplateElementService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IReportGroupService, ReportGroupService>();
builder.Services.AddScoped<IReportElementService, ReportElementService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();


//Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//GenericRepository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));



var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy, builder => {
        //builder.WithOrigins("http://localhost:800").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
        //builder.SetIsOriginAllowed(origin => true);
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(devCorsPolicy);
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();



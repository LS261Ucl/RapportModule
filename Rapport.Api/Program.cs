using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Rapport.BusinessLogig.Interfaces;
using Rapport.BusinessLogig.Services;
using Rapport.Data;
using Rapport.Entites.Identity;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using System.Text.Json.Serialization;
using IMailService = Rapport.BusinessLogig.Interfaces.IMailService;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
//add in to azure Sqlserver in cloud       
builder.Services.AddDbContext<ReportDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReportConnection"));

});

//if i hade to database this should have been separatet form the rest. to provide more security.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));

});
//builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
//             .AddEntityFrameworkStores<ApplicationDbContext>();

//Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// For Identity
builder.Services.AddIdentity<AppUser, UserRoles>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

//// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});


//Add authorization in swagger
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

//SendEmail
var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");

//Services
builder.Services.AddScoped<ITemplateService, TemplateService>();
builder.Services.AddScoped<ITemplateGroupService, TemplateGroupService>();
builder.Services.AddScoped<ITemplateElementService, TemplateElementService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IReportGroupService, ReportGroupService>();
builder.Services.AddTransient<IMailService, MailService>();


builder.Services.AddScoped<IReportElementService, ReportElementService>();


builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();


//Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//GenericRepository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));




builder.Services.AddHttpContextAccessor();


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

app.UseAuthentication();

app.UseAuthorization();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(devCorsPolicy);
}

app.UseHttpsRedirection();




app.MapControllers();

app.Run();



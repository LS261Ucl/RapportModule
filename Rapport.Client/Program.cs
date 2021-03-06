global using Rapport.Client.Helpers;
global using Rapport.Client.Interfaces;
global using Rapport.Shared.Dto_er.Template;
global using Rapport.Shared.Dto_er.Report;
global using Blazored.Modal;
global using Blazored.Modal.Services;
global using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Rapport.Client;
using Rapport.Client.Service;
using Rapport.Client.Extensions;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddHttpClient();

builder.Services.AddHttpClient("ReportUri", (sp, cl) =>
{
    cl.BaseAddress = new Uri("https://localhost:7109/api/");
});


builder.Services.AddBlazoredModal();

builder.Services.AddAuthorizationCore();    

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(
    sp => sp.GetService<IHttpClientFactory>().CreateClient("RapportAPI"));


//Add Services 
builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<ITemplateService, TemplateService>();
builder.Services.AddScoped<ITemplateGroupService, TemplateGroupService>();
builder.Services.AddScoped<ITemplateElementService, TemplateElementService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IReportGroupService, ReportGroupService>();
builder.Services.AddScoped<IReportElementService, ReportElementService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<global::Blazored.Modal.Services.IModalService, global::Blazored.Modal.Services.ModalService>();


//der.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(serviceProvider => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


await builder.Build().RunAsync();
    
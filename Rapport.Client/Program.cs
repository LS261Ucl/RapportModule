global using Rapport.Client.Helpers;
global using Rapport.Client.Interfaces;
global using Rapport.Shared.Dto_er.Template;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Rapport.Client;
using Rapport.Client.Service;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddHttpClient();

builder.Services.AddHttpClient("ReportUri", (sp, cl) =>
{
    cl.BaseAddress = new Uri("https://localhost:7174/api/");
});


//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(
    sp => sp.GetService<IHttpClientFactory>().CreateClient("Rapport.Api"));


//Add Services 
builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<ITemplateService, TemplateService>();
builder.Services.AddScoped<ITemplateGroupService, TemplateGroupService>();
builder.Services.AddScoped<ITemplateElementService, TemplateElementService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IReportGroupService, ReportGroupService>();
builder.Services.AddScoped<IReportElementService, ReportElementService>();

//der.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(serviceProvider => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });

await builder.Build().RunAsync();

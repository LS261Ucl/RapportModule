using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Rapport.Data;
using Rapport.Shared.Dto_er.Identity;
using Rapport.Shared.Dto_er.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UnitTest.IntegrationsTest
{
    public class Integrationstest : IDisposable
    {
        protected readonly HttpClient TestClient;
        protected const string BaseUrl = "https://localhost:5002/api/";
        private readonly IServiceProvider _serviceProvider;

        // Creates WebAppFactory where it gets the DbContext service at runtime and replaces it with InMemoryDb
        protected Integrationstest()
        {
            var appFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var databaseDescriptor = services.SingleOrDefault(x =>
                        x.ServiceType == typeof(DbContextOptions<ReportDbContext>));

                    if (databaseDescriptor != null)
                        services.Remove(databaseDescriptor);

                    services.AddDbContext<ReportDbContext>(opt =>
                        opt.UseInMemoryDatabase("TestDb"));
                });
            });

            _serviceProvider = appFactory.Services;
            TestClient = appFactory.CreateClient();
        }

        // Gets Jwt Token and sets it to the AuthenticationHeaderValue
        protected async Task AuthenticateAsync(string email = "mikkel@delpin.dk")
        {
            TestClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await LoginAndGetJwtAsync(email));
        }

        // Logs in user and returns Jwt token
        private async Task<string> LoginAndGetJwtAsync(string email)
        {
            var response = await TestClient.PostAsJsonAsync(BaseUrl + "account/login",
                new LoginDto { Email = email, Password = "Pa$$w0rd" });

            var loginResponse = await response.Content.ReadFromJsonAsync<UserDto>();

            return loginResponse?.Token;
        }

        protected static JsonSerializerOptions ReferenceHandlerOptions =>
            new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve };

        // Disposes of InMemory database after each test has run
        public void Dispose()
        {
            using var serviceScope = _serviceProvider.CreateScope();
            var databaseContext = serviceScope.ServiceProvider.GetService<ReportDbContext>();

            databaseContext?.Database.EnsureDeleted();

            GC.SuppressFinalize(this);
        }
    }
}

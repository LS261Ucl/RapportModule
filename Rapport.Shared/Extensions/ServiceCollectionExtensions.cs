using Blazored.Modal.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Rapport.Shared.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazoredModal(this IServiceCollection services)
      => services.AddScoped<IModalService, ModalService>();
    }
}

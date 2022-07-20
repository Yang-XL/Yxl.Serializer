using Microsoft.Extensions.DependencyInjection;
using System;

namespace Yxl.Serializer.Configurations
{
    public static class DI
    {
        public static IServiceCollection AddYxlSerializer(this IServiceCollection services, Action<SerializerOptions> setupAction)
        {
            services.AddSingleton<ISerializerProvider, DefaultSerializerProvider>();
            var options = new SerializerOptions();
            setupAction?.Invoke(options);
            foreach (var serviceExtension in options.Extensions)
            {
                serviceExtension.AddServices(services);
            }
            services.AddSingleton(options);
            return services;
        }
    }
}

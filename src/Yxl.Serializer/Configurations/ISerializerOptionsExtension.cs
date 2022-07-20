using Microsoft.Extensions.DependencyInjection;

namespace Yxl.Serializer.Configurations
{
    public interface ISerializerOptionsExtension
    {
        /// <summary>
        /// Adds the services.
        /// </summary>
        /// <param name="services">Services.</param>
        void AddServices(IServiceCollection services);
    }

  
}

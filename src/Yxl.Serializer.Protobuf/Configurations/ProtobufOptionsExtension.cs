using Microsoft.Extensions.DependencyInjection;
using Yxl.Serializer.Configurations;

namespace Yxl.Serializer.Protobuf.Configurations
{
    /// <summary>
    /// Protobuf options extension.
    /// </summary>
    internal sealed class ProtobufOptionsExtension : ISerializerOptionsExtension
    {
        /// <summary>
        /// The name.
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Yxl.Serializer.Protobuf.Configurations.ProtobufOptionsExtension"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        public ProtobufOptionsExtension(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Adds the services.
        /// </summary>
        /// <param name="services">Services.</param>
        public void AddServices(IServiceCollection services)
        {
            services.AddSingleton<ISerializer, DefaultProtobufSerializer>(x =>
            {
                return new DefaultProtobufSerializer(_name);
            });
            services.AddSingleton<IProtobufSerializer, DefaultProtobufSerializer>(x =>
            {
                return new DefaultProtobufSerializer(_name);
            });
        }
    }
}

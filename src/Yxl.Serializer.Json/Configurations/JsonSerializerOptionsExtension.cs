using System;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Yxl.Serializer.Configurations;

namespace Yxl.Serializer.Json.Configurations
{
    /// <summary>
    /// Json options extension.
    /// </summary>
    internal sealed class JsonSerializerOptionsExtension : ISerializerOptionsExtension
    {
        /// <summary>
        /// The name.
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// The configure.
        /// </summary>
        private readonly Action<JsonSerializerSettings> _configure;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Yxl.Serializer.Json.Configurations.JsonSerializerOptionsExtension"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="configure">Configure.</param>
        public JsonSerializerOptionsExtension(string name, Action<JsonSerializerSettings> configure)
        {
            _name = name;
            _configure = configure;
        }

        /// <summary>
        /// Adds the services.
        /// </summary>
        /// <param name="services">Services.</param>
        public void AddServices(IServiceCollection services)
        {
            Action<JsonSerializerSettings> configure = x => { };

            if (_configure != null) configure = _configure;

            services.AddOptions();
            services.Configure(_name, configure);
            services.AddSingleton<ISerializer, DefaultJsonSerializer>(x =>
            {
                var optionsMon = x.GetRequiredService<Microsoft.Extensions.Options.IOptionsMonitor<JsonSerializerSettings>>();
                var options = optionsMon.Get(_name);
                return new DefaultJsonSerializer(_name, options);
            });

            services.AddSingleton<IJsonSerializer, DefaultJsonSerializer>(x =>
            {
                var optionsMon = x.GetRequiredService<Microsoft.Extensions.Options.IOptionsMonitor<JsonSerializerSettings>>();
                var options = optionsMon.Get(_name);
                return new DefaultJsonSerializer(_name, options);
            });
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using Yxl.Serializer.Configurations;

namespace Yxl.Serializer.SystemTextJson.Configurations
{
    /// <summary>
    /// Json options extension.
    /// </summary>
    internal sealed class TextJsonOptionsExtension : ISerializerOptionsExtension
    {
        /// <summary>
        /// The name.
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// The configure.
        /// </summary>
        private readonly Action<JsonSerializerOptions> _configure;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EasyCaching.Serialization.SystemTextJson.JsonOptionsExtension"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="configure">Configure.</param>
        public TextJsonOptionsExtension(string name, Action<JsonSerializerOptions> configure)
        {
            _name = name;
            _configure = configure;
        }

        public void AddServices(IServiceCollection services)
        {
            Action<JsonSerializerOptions> configure = x => { };

            if (_configure != null) configure = _configure;

            services.AddOptions();
            services.Configure(_name, configure);
            services.AddSingleton<ISerializer, DefaultTextJsonSerializer>(x =>
            {
                var optionsMon = x.GetRequiredService<Microsoft.Extensions.Options.IOptionsMonitor<JsonSerializerOptions>>();
                var options = optionsMon.Get(_name);
                return new DefaultTextJsonSerializer(_name, options);
            });
        }
    }
}

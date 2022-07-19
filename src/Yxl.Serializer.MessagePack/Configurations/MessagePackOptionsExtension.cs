using Microsoft.Extensions.DependencyInjection;
using System;
using Yxl.Serializer.Configurations;

namespace Yxl.Serializer.MessagePack.Configurations
{
    /// <summary>
    /// Message pack options extension.
    /// </summary>
    internal sealed class MessagePackOptionsExtension : ISerializerOptionsExtension
    {
        /// <summary>
        /// The name.
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// The configure.
        /// </summary>
        private readonly Action<MsgPackSerializerOptions> _configure;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Yxl.Serializer.MessagePack.Configurations.MessagePackOptionsExtension"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="configure">Configure.</param>
        public MessagePackOptionsExtension(string name, Action<MsgPackSerializerOptions> configure)
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
            Action<MsgPackSerializerOptions> configure = x => { };

            if (_configure != null) configure = _configure;

            services.AddOptions();
            services.Configure(_name, configure);
            services.AddSingleton<ISerializer, DefaultMessagePackSerializer>(x =>
            {
                var optionsMon = x.GetRequiredService<Microsoft.Extensions.Options.IOptionsMonitor<MsgPackSerializerOptions>>();
                var options = optionsMon.Get(_name);
                return new DefaultMessagePackSerializer(_name, options);
            });
            services.AddSingleton<IMessagePackSerializer, DefaultMessagePackSerializer>(x =>
            {
                var optionsMon = x.GetRequiredService<Microsoft.Extensions.Options.IOptionsMonitor<MsgPackSerializerOptions>>();
                var options = optionsMon.Get(_name);
                return new DefaultMessagePackSerializer(_name, options);
            });
        }
    }
}

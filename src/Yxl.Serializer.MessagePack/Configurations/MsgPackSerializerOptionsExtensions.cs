using System;
using Yxl.Serializer.Configurations;

namespace Yxl.Serializer.MessagePack.Configurations
{
    /// <summary>
    /// MsgPackSerializerOptionsExtensions
    /// </summary>
    public static class MsgPackSerializerOptionsExtensions
    {
        /// <summary>
        /// Withs the message pack serializer.
        /// </summary>
        /// <param name="options">Options.</param>
        /// <param name="name">The name of this serializer instance.</param>        
        public static SerializerOptions WithMessagePack(this SerializerOptions options, string name = "msgpack")
        {
            Action<MsgPackSerializerOptions> action = x =>
            {
                x.EnableCustomResolver = false;
            };

            options.RegisterExtension(new MessagePackOptionsExtension(name, action));

            return options;
        }

        /// <summary>
        /// Withs the message pack serializer.
        /// </summary>        
        /// <param name="options">Options.</param>
        /// <param name="action">Configure serializer settings.</param>
        /// <param name="name">The name of this serializer instance.</param>     
        public static SerializerOptions WithMessagePack(this SerializerOptions options, Action<MsgPackSerializerOptions> action, string name)
        {
            options.RegisterExtension(new MessagePackOptionsExtension(name, action));

            return options;
        }
    }
}

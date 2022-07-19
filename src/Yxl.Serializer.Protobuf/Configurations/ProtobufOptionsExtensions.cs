using Yxl.Serializer.Configurations;

namespace Yxl.Serializer.Protobuf.Configurations
{
    /// <summary>
    /// Protobuf options extensions.
    /// </summary>
    public static class ProtobufOptionsExtensions
    {
        /// <summary>
        /// Withs the protobuf serializer.
        /// </summary>        
        /// <param name="options">Options.</param>
        /// <param name="name">The name of this serializer instance.</param>   
        public static SerializerOptions WithProtobuf(this SerializerOptions options, string name = "proto")
        {
            options.RegisterExtension(new ProtobufOptionsExtension(name));

            return options;
        }
    }
}

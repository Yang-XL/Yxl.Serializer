namespace Yxl.Serializer.MessagePack.Configurations
{
    /// <summary>
    /// MsgPackSerializerOptions
    /// </summary>
    public class MsgPackSerializerOptions
    {
        /// <summary>
        /// Whethe to enable custom resolver
        /// </summary>
        public bool EnableCustomResolver { get; set; }

        /// <summary>
        /// The custom resolver you want to use
        /// </summary>
        public global::MessagePack.IFormatterResolver CustomResolvers { get; set; }
    }
}

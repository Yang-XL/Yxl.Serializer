using System.Collections.Generic;

namespace Yxl.Serializer.Configurations
{
    public class SerializerOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Yxl.Serializer.Configurations.SerializerOptions"/> class.
        /// </summary>
        public SerializerOptions()
        {
            Extensions = new List<ISerializerOptionsExtension>();
        }

        /// <summary>
        /// Gets the extensions.
        /// </summary>
        /// <value>The extensions.</value>
        internal IList<ISerializerOptionsExtension> Extensions { get; }

        /// <summary>
        /// Registers the extension.
        /// </summary>
        /// <param name="extension">Extension.</param>
        public void RegisterExtension(ISerializerOptionsExtension extension)
        {
            Extensions.Add(extension);
        }
    }
}

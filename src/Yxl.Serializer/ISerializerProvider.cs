using System;
using System.Collections.Generic;
using System.Linq;

namespace Yxl.Serializer
{
    public interface ISerializerProvider
    {
        ISerializer CreateSerializer(string name);
    }

    public class DefaultSerializerProvider : ISerializerProvider
    {
        private readonly IEnumerable<ISerializer> _serializers;

        public DefaultSerializerProvider(IEnumerable<ISerializer> serializers)
        {
            _serializers = serializers;
        }

        public ISerializer CreateSerializer(string name)
        {
            return _serializers.First(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}

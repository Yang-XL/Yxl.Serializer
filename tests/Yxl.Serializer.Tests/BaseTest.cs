using Microsoft.Extensions.DependencyInjection;
using Yxl.Serializer.Configurations;
using Yxl.Serializer.Json.Configurations;
using Yxl.Serializer.MessagePack.Configurations;
using Yxl.Serializer.Protobuf.Configurations;
using Yxl.Serializer.SystemTextJson.Configurations;

namespace Yxl.Serializer.Tests
{
    [TestClass]
    public class BaseTest
    {
        protected static IServiceProvider serviceProvider;

        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            context.WriteLine("AssemblyInit Begin");
            var _services = new ServiceCollection();
            _services.AddYxlSerializer(options =>
            {
                options.WithJson();
                options.WithMessagePack();
                options.WithProtobuf();
                options.WithSystemTextJson();
            });
            serviceProvider = _services.BuildServiceProvider();
            context.WriteLine("AssemblyInit End");

        }
    }
}

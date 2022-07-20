using Microsoft.Extensions.DependencyInjection;
using MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yxl.Serializer.Json;

namespace Yxl.Serializer.Tests
{
    [TestClass]
    public class NewtonJsonTest : BaseTest
    {

        protected ISerializerProvider serializerProvider;
        protected IJsonSerializer jsonSerializer;

        [ClassInitialize]
        public static async Task Init(TestContext context)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("RespositoryTest Is running");
            });
        }
        [TestInitialize]
        public void GetRepository()
        {
            serializerProvider = serviceProvider.GetRequiredService<ISerializerProvider>();
            jsonSerializer = serviceProvider.GetRequiredService<IJsonSerializer>();

        }
        [TestMethod]
        public void OneTest()
        {
            var se = serializerProvider.CreateSerializer("NewtonsoftJson");
            var s = se.Serialize(Store.AnyObj());
            var s2 = jsonSerializer.Serialize(Store.AnyObj());
            Assert.AreEqual(s.Length, s2.Length);
        }
    }
}

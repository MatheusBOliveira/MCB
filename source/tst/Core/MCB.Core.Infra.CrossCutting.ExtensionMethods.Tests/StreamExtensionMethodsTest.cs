using MCB.Core.Infra.CrossCutting.Tests;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Core.Infra.CrossCutting.ExtensionMethods.Tests
{
    public class StreamExtensionMethodsTest
        : TestBase<StreamExtensionMethodsTest>
    {
        public StreamExtensionMethodsTest(ITestOutputHelper output) 
            : base(output)
        {
        }

        protected override void ConfigureServices(IServiceCollection services)
        {

        }

        [Fact]
        [Trait("ExtensionMethods", "GetStringTest")]
        public void GetStringTest()
        {
            var text = "Marcelo Castelo Branco";
            var memoryStream = new MemoryStream();
            memoryStream.Write(Encoding.UTF8.GetBytes(text));

            var streamText = memoryStream.GetString();

            Assert.Equal(text, streamText);
        }
    }
}



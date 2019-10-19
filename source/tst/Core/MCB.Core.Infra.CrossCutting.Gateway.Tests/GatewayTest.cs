using MCB.Core.Infra.CrossCutting.Tests;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Xunit.Abstractions;
using Xunit;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Gateway.Tests
{
    public class GatewayTest
        : TestBase<GatewayTest>
    {
        public GatewayTest(ITestOutputHelper output) 
            : base(output)
        {

        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            IoC.BootStrapper.RegisterServices(services, new string[] {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "routes.json")
            });
        }

        [Fact]
        [Trait("GatewayTest", "DefaultTest")]
        public async Task DefaultTest()
        {
            var gatewayManager = ServiceProvider.GetService<GatewayManager>();
            await gatewayManager.RouteRequest(
                "/api/v1.0/login",
                "?applicationId=560D54E6-F2CA-42C6-A873-DD268C883DCB&keepConnected=true",
                null,
                null,
                "GET",
                q => {
                    var newUri = $"{q.RoutedUri} ({q.Verb})";
                    return newUri;
                });
        }
    }
}



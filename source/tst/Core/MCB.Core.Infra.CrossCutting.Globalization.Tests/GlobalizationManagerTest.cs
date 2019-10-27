using MCB.Core.Infra.CrossCutting.Globalization.Interfaces;
using MCB.Core.Infra.CrossCutting.Tests;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Core.Infra.CrossCutting.Globalization.Tests
{
    public class GlobalizationManagerTest
        : TestBase<GlobalizationManagerTest>
    {
        public GlobalizationManagerTest(ITestOutputHelper output) 
            : base(output)
        {
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            IoC.BootStrapper.RegisterServices(services, null);
        }

        [Fact]
        [Trait("Globalization", "GetMessageTest")]
        public void GetMessageTest()
        {
            var globalizationManager = ServiceProvider.GetService<IGlobalizationManager>();

            var msg1ptBR = globalizationManager.GetMessage("MCB-CORE-INF-CROSSTEST-1", "pt-BR");
            var msg1enUS = globalizationManager.GetMessage("MCB-CORE-INF-CROSSTEST-1", "en-US");

            var msg2ptBR = globalizationManager.GetMessage("MCB-CORE-INF-CROSSTEST-2", "pt-BR");
            var msg2enUS = globalizationManager.GetMessage("MCB-CORE-INF-CROSSTEST-2", "en-US");

            Assert.True(
                msg1ptBR.Equals("Mensagem A.")
                && msg1enUS.Equals("Message A.")
                && msg2ptBR.Equals("Mensagem B.")
                && msg2enUS.Equals("Message B.")
                );
        }
    }
}



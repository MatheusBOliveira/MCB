using MCB.Core.Infra.CrossCutting.Tests;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Core.Infra.CrossCutting.Security.Tests
{
    public class CryptographyTest
        : TestBase<CryptographyTest>
    {
        public CryptographyTest(ITestOutputHelper output) 
            : base(output)
        {

        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            IoC.BootStrapper.RegisterServices(services, null);
        }

        [Fact]
        [Trait("Cryptography", "EncryptAndDecryptTest")]
        public void EncryptAndDecryptTest()
        {
            var crypto = ServiceProvider.GetService<Cryptography>();

            var name = "Marcelo Castelo Branco";
            var encryptedName = crypto.Encrypt(name);
            var decryptedName = crypto.Decrypt(encryptedName);

            Assert.Equal(name, decryptedName);
        }

        [Fact]
        [Trait("Cryptography", "EncryptHashTest")]
        public void EncryptHashTest()
        {
            var crypto = ServiceProvider.GetService<Cryptography>();

            var name = "Marcelo Castelo Branco";
            var hashValue1 = crypto.EncryptWithHash(name); 
            var hashValue2 = crypto.EncryptWithHash("Marcelo Castelo Branco");

            Assert.Equal(hashValue1, hashValue2);
        }
    }
}



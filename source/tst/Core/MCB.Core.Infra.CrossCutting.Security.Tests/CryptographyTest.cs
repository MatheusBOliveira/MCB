using MCB.Core.Infra.CrossCutting.Security.Interfaces;
using MCB.Core.Infra.CrossCutting.Tests;
using Microsoft.Extensions.DependencyInjection;
using System;
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
            IoC.DefaultBootstrapper.RegisterServices(services);
        }
        protected override void ServiceProviderGenerated(IServiceProvider serviceProvider)
        {

        }

        [Fact]
        [Trait("Cryptography", "EncryptAndDecryptTest")]
        public void EncryptAndDecryptTest()
        {
            var crypto = ServiceProvider.GetService<ICryptography>();

            var name = "Marcelo Castelo Branco";
            var encryptedName = crypto.Encrypt(name);
            var decryptedName = crypto.Decrypt(encryptedName);

            Assert.Equal(name, decryptedName);
        }

        [Fact]
        [Trait("Cryptography", "EncryptHashTest")]
        public void EncryptHashTest()
        {
            var crypto = ServiceProvider.GetService<ICryptography>();

            var name = "Marcelo Castelo Branco";
            var hashValue1 = crypto.EncryptWithHash(name); 
            var hashValue2 = crypto.EncryptWithHash("Marcelo Castelo Branco");

            Assert.Equal(hashValue1, hashValue2);
        }
    }
}



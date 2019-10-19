using MCB.Core.Infra.CrossCutting.Tests;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Core.Infra.CrossCutting.ExtensionMethods.Tests
{
    class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public UserDetail UserDetail { get; set; }

        public User()
        {
            UserDetail = new UserDetail();
        }
    }
    class UserDetail
    {
        public string Observation { get; set; }
    }

    public class StringExtensionMethodsTest
        : TestBase<StringExtensionMethodsTest>
    {
        public StringExtensionMethodsTest(ITestOutputHelper output) 
            : base(output)
        {
        }

        protected override void ConfigureServices(IServiceCollection services)
        {

        }

        [Fact]
        [Trait("ExtensionMethods", "DeserializeFromJsonTest")]
        public void DeserializeFromJsonTest()
        {
            var user = new User
            {
                Name = "Marcelo Castelo Branco",
                Email = "marcelo.castelo@outlook.com",
                UserDetail = new UserDetail
                {
                    Observation = "obs A"
                }
            };

            var json = @"{ ""name"": ""Marcelo Castelo Branco"", ""email"": ""marcelo.castelo@outlook.com"", ""userdetail"": { ""observation"": ""obs A"" } }";
            var userDeserialized = json.DeserializeFromJson<User>();

            Assert.True(
                user.Name == userDeserialized.Name
                && user.Email == userDeserialized.Email
                && user.UserDetail.Observation == userDeserialized.UserDetail.Observation
                );
        }

        [Fact]
        [Trait("ExtensionMethods", "LengthIsBetweenTest")]
        public void LengthIsBetweenTest()
        {
            var text = "Marcelo Castelo Branco";

            Assert.True(
                text.LengthIsBetween(text.Length - 1, text.Length + 1));
        }
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IqOptionApi.TestHelpers;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Shouldly;

namespace IqOptionApi.DependencyInjection.Tests.Integrations
{
    [System.ComponentModel.Category(Categories.Unit)]
    public class ServicesCollectionIntegrationTest : TestFor<ServiceCollection> {
        
        [SetUp]
        public void Setup() {
            
            Suite.AddIqOption(cfg => 
                    cfg
                        .UseEmailAddress("EmailAddress")
                        .UsePassword("Password")
                        .UseExternalEndPoints("AnyEndPoints"));

        }

        [Test]
        public void AddIqOption_WithDependencyInjection_ObjectResolveCorrectly() {

            // arrange
            var provider = Suite.BuildServiceProvider();

            // act
            var api = provider.GetService<IIqOptionApi>();

            // assert
            api.ShouldNotBeNull();
        }
    }
}

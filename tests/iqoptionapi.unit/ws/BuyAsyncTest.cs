using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using IqOptionApi.Models;
using Xunit;

namespace IqOptionApi.unit.ws {
    [Trait("Category", "Integration")]
    public class BuyAsyncTest : IClassFixture<BaseUnitTest> {
        private readonly BaseUnitTest _baseTest;


        public BuyAsyncTest(BaseUnitTest baseTest) {
            _baseTest = baseTest;
        }

        [Fact]
        public async Task OpenOTCTest() {

            var api = _baseTest.Resolve<IIqOptionApi>();

            api.InfoDatasObservable.Select(x => x[0]).Subscribe(x => {
                Console.WriteLine(x.ToString());
            });

            
            //arrange
            var result = await api.BuyAsync(ActivePair.EURUSD_OTC, 1, OrderDirection.Call, DateTimeOffset.Now);


        }
    }
}
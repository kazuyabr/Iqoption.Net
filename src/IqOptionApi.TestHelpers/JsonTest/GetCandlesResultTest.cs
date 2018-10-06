using System;
using System.Linq;
using IqOptionApi.ws;
using NUnit.Framework;
using Shouldly;

namespace IqOptionApi.TestHelpers.JsonTest {
    [JsonTest("GetCandles_Success")]
    public class GetCandlesResultTest : JsonTestSuiteFor<GetCandleItemsResultMessage> {
        [Test]
        public void GetCandlesResult_CandlesItems_ResultMustReturnSuccess() {
            //assert
            Suite.Message.Infos.ShouldNotBeEmpty();

            var candles = Suite.Message.Infos.FirstOrDefault(x => x.Id == 17990335);
            candles.ShouldNotBeNull();
            candles.Open.ShouldBe(1.14384);
            candles.Close.ShouldBe(1.143865);
            candles.Min.ShouldBe(1.14384);
            candles.Max.ShouldBe(1.143865);
        }

        [Test]
        public void GetCandlesResult_WithFromAndTo_DateTimeMustSetCorrectly() {
            //assert
            Suite.Message.Infos.ShouldNotBeEmpty();

            var candles = Suite.Message.Infos.FirstOrDefault(x => x.Id == 17990335);

            var from = DateTimeOffset.FromUnixTimeSeconds(1534539516).ToLocalTime();

            candles.From.ShouldBe(from);
        }


        [Test]
        public void GetCandlesResult_WithSuccessFul_ResultMustReturnSuccess() {
            //assert
            Suite.ShouldNotBeNull();
            Suite.Message.ShouldNotBeNull();
            Suite.Message.Count.ShouldBe(100);
        }
    }
}
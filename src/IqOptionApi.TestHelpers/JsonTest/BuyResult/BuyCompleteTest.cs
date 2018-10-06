using System;
using iqoptionapi.ws.result;
using NUnit.Framework;
using Shouldly;

namespace IqOptionApi.TestHelpers.JsonTest.BuyResult {
    [JsonTest("buycomplete")]
    public class BuyCompleteTest : JsonTestSuiteFor<BuyCompleteResultMessage> {
        [Test]
        public void LoadBuyComplete_WithSuccessResult_DateTimeConverted() {
            // assert
            Suite.ShouldNotBeNull();
            Suite.Message.ShouldNotBeNull();

            var msg = Suite.Message;
            msg.IsSuccessful.ShouldBeTrue();
            msg.GetMessageDescription().ShouldBe("Successful");

            var buy = msg.Result;

            buy.Created.ShouldNotBeNull();
            buy.Exp.ShouldNotBeNull();

            buy.UserId.ShouldBe(1234);
        }


        [Test]
        public void LoadBuyComplete_ValidateUserData() {
            // assert
            var buy = Suite.Message.Result;

            buy.Created.ShouldNotBeNull();
            buy.Exp.ShouldNotBeNull();

            buy.UserId.ShouldBe(1234);
        }

        [Test]
        public void LoadBuyComplete_ValidateDate() {
            // assert
            var buy = Suite.Message.Result;

            buy.Created.ShouldNotBeNull();
            var exp = DateTimeOffset.FromUnixTimeSeconds(1535448900);
            buy.Exp.ShouldBe(exp);

            var created = DateTimeOffset.FromUnixTimeSeconds(1535448820);
            buy.Created.ShouldBe(created);

            var timeRate = DateTimeOffset.FromUnixTimeSeconds(1535448820);
            buy.TimeRate.ShouldBe(timeRate);
        }
    }
}
using iqoptionapi.ws.result;
using IqOptionApi.TestHelpers;
using NUnit.Framework;
using Shouldly;

namespace IqOptionApi.Tests.JsonTest.BuyResult {
    [JsonTest("buyFailed")]
    public class BuyCompleteResultMessageWithFailedTest : JsonTestSuiteFor<BuyCompleteResultMessage> {
        [Test]
        public void LoadBuyComplete_WithSuccessResult_DateTimeConverted() {
            // assert
            Suite.ShouldNotBeNull();
            Suite.Message.ShouldNotBeNull();

            var msg = Suite.Message;
            msg.IsSuccessful.ShouldBeFalse();
            msg.GetMessageDescription().ShouldBe("หมดเวลาสำหรับการซื้อออปชันแล้ว โปรดลองอีกครั้งภายหลัง");
        }
    }
}
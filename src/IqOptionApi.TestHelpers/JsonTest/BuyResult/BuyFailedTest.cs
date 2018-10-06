using iqoptionapi.ws.result;
using NUnit.Framework;
using Shouldly;

namespace IqOptionApi.TestHelpers.JsonTest.BuyResult {
    [JsonTest("buyFailed")]
    public class BuyFailedTest : JsonTestSuiteFor<BuyCompleteResultMessage> {
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
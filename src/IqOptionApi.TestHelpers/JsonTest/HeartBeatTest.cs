using IqOptionApi.Models;
using NUnit.Framework;
using Shouldly;

namespace IqOptionApi.TestHelpers.JsonTest {
    [JsonTest("heartbeat")]
    public class HeartBeatTest : JsonTestSuiteFor<HeartBeat> {
        [Test]
        public void ConvertHeartbeat_WithExistingValue_ValuedConverted() {
            Suite.Message.ShouldNotBeNull();
            Suite.Name.ShouldBe("heartbeat");
        }
    }
}
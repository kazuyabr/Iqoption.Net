using IqOptionApi.Models;
using IqOptionApi.TestHelpers;
using NUnit.Framework;
using Shouldly;

namespace IqOptionApi.Tests.JsonTest {
    [JsonTest("heartbeat")]
    public class HeartBeatTest : JsonTestSuiteFor<HeartBeat> {
        [Test]
        public void ConvertHeartbeat_WithExistingValue_ValuedConverted() {
            Suite.Message.ShouldNotBeNull();
            Suite.Name.ShouldBe("heartbeat");
        }
    }
}
using System;
using IqOptionApi.Models;
using IqOptionApi.Tests.JsonTest;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;

namespace IqOptionApi.TestHelpers.JsonTest {
    
    [JsonTest("timesync.json")]
    public class ServerTimeTest : JsonTestSuiteFor<ServerTime>
    {
        [Test]
        public void GetTimeSync_WithExistingValue_DateTimeOffsetConvertedCorrected() {

            // act
            var result = TryToParseJson();

            // assert
            var dt = DateTimeOffset.FromUnixTimeMilliseconds(1534749220468);

            result.ShouldNotBeNull();
            result.Message.ShouldBe(dt);
        }
    }
}
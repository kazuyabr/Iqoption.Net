using System;
using IqOptionApi.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;

namespace IqOptionApi.TestHelpers.JsonTest {

    [JsonTest("heartbeat.json")]
    public class HeartBeatTest : JsonTestSuiteFor<HeartBeat>
    {
        private readonly JsonFileTest _test;
        private string Json => _test.LoadJson("heartbeat.json");
        public HeartBeatTest(JsonFileTest test) {
            _test = test;
        }


        [Test]
        public void ConvertHeartbeat_WithExistingValue_ValuedConverted() {

            // act
            var result = JsonConvert.DeserializeObject<HeartBeat>(Json);


            // assert

            var dt = DateTimeOffset.FromUnixTimeMilliseconds(1534749247713);

            result.ShouldNotBeNull();
            result.Message.ShouldBe(dt);
        }
    }
}
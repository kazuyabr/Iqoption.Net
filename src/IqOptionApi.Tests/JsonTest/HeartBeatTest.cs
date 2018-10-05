﻿
using System;
using IqOptionApi.Models;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace IqOptionApi.Tests.JsonTest {
    public class HeartBeatTest : IClassFixture<LoadJsonFileTest>
    {
        private readonly LoadJsonFileTest _loadTest;
        private string Json => _loadTest.LoadJson("heartbeat.json");
        public HeartBeatTest(LoadJsonFileTest loadTest) {
            _loadTest = loadTest;
        }


        [Fact]
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
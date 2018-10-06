using System;
using IqOptionApi.Models;
using IqOptionApi.TestHelpers;
using NUnit.Framework;
using Shouldly;

namespace IqOptionApi.Tests.JsonTest {
    [JsonTest("timesync")]
    public class ServerTimeTest : JsonTestSuiteFor<ServerTime> {
        [Test]
        public void GetTimeSync_WithExistingValue_DateTimeOffsetConvertedCorrected() {

            // assert
            var dt = DateTimeOffset.FromUnixTimeMilliseconds(1534749220468);

            Suite.ShouldNotBeNull();
            Suite.Message.ShouldBe(dt);
        }

        [Test]
        public void GettimeSync_WithReadFromFile_FileValid() {
            Suite.Message.ShouldNotBeNull();
            Suite.Name.ShouldBe("timeSync");
        }
    }
}
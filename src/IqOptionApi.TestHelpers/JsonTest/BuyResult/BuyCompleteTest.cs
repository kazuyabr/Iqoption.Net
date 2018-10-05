using System;
using iqoptionapi.ws.result;
using IqOptionApi.Models;
using IqOptionApi.TestHelpers.JsonTest;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;

namespace IqOptionApi.Tests.JsonTest
{
    public class BuyCompleteTest : JsonFileTest {
        private readonly JsonFileTest _jsonLoader;

        public readonly string Json;

        public BuyCompleteTest(JsonFileTest jsonLoader) {
            _jsonLoader = jsonLoader;

            Json = _jsonLoader.LoadJson("BuyResult\\buycomplete.json");
        }


        [Test]
        public void LoadBuyComplete_WithSuccessResult_DateTimeConverted() {

            // act
            var result = JsonConvert.DeserializeObject<BuyCompleteResultMessage>(Json);

            // assert
            result.ShouldNotBeNull();
            result.Message.ShouldNotBeNull();

            var msg = result.Message;
            msg.IsSuccessful.ShouldBeTrue();
            msg.GetMessageDescription().ShouldBe("Successful");

            var buy = msg.Result;

            buy.Created.ShouldNotBeNull();
            buy.Exp.ShouldNotBeNull();

            buy.UserId.ShouldBe(1234);
        }


        [Test]
        public void LoadBuyComplete_ValidateUserData() {

            // act
            var result = JsonConvert.DeserializeObject<BuyCompleteResultMessage>(Json);

            // assert
            var buy = result.Message.Result;

            buy.Created.ShouldNotBeNull();
            buy.Exp.ShouldNotBeNull();

            buy.UserId.ShouldBe(1234);
        }

        [Test]
        public void LoadBuyComplete_ValidateDate()
        {

            // act
            var result = JsonConvert.DeserializeObject<BuyCompleteResultMessage>(Json);

            // assert
            var buy = result.Message.Result;

            buy.Created.ShouldNotBeNull();
            var exp = DateTimeOffset.FromUnixTimeSeconds(1535448900);
            buy.Exp.ShouldBe(exp);

            var created = DateTimeOffset.FromUnixTimeSeconds(1535448820);
            buy.Created.ShouldBe(created);

            var timeRate  = DateTimeOffset.FromUnixTimeSeconds(1535448820);
            buy.TimeRate.ShouldBe(timeRate);
        }
    }
}
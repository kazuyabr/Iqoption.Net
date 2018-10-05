using System;
using iqoptionapi.ws.result;
using IqOptionApi.Models;
using IqOptionApi.TestHelpers;
using IqOptionApi.TestHelpers.JsonTest;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;


namespace IqOptionApi.Tests.JsonTest
{
    public class BuyFailedTest : TestFor<JsonFileTest>
    {
        private readonly JsonFileTest _jsonLoader;

        public readonly string Json;

        public BuyFailedTest(JsonFileTest jsonLoader)
        {
            _jsonLoader = jsonLoader;

            Json = _jsonLoader.LoadJson("BuyResult\\buyFailed.json");
        }

        [Test]
        public void LoadBuyComplete_WithSuccessResult_DateTimeConverted()
        {

            // act
            var result = JsonConvert.DeserializeObject<BuyCompleteResultMessage>(Json);

            // assert
            result.ShouldNotBeNull();
            result.Message.ShouldNotBeNull();

            var msg = result.Message;
            msg.IsSuccessful.ShouldBeFalse();
            msg.GetMessageDescription().ShouldBe("หมดเวลาสำหรับการซื้อออปชันแล้ว โปรดลองอีกครั้งภายหลัง");

        }


    }
}
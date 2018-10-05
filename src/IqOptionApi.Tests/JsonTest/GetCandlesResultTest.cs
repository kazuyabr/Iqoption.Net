﻿using System;
using System.Linq;
using IqOptionApi.ws;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace IqOptionApi.Tests.JsonTest {
    public class GetCandlesResultTest : IClassFixture<LoadJsonFileTest> {
        public GetCandlesResultTest(LoadJsonFileTest loadJsonFileTest) {
            _loadJsonFileTest = loadJsonFileTest;

            GetCandlesSuccessJson = _loadJsonFileTest.LoadJson("candles\\GetCandles_Success.json");
        }

        private readonly LoadJsonFileTest _loadJsonFileTest;

        private string GetCandlesSuccessJson { get; }

        [Fact]
        public void GetCandlesResult_CandlesItems_ResultMustReturnSuccess() {

            //act
            var result = JsonConvert.DeserializeObject<GetCandleItemsResultMessage>(GetCandlesSuccessJson);


            //assert
            result.Message.Infos.ShouldNotBeEmpty();

            var candles = result.Message.Infos.FirstOrDefault(x => x.Id == 17990335);
            candles.ShouldNotBeNull();
            candles.Open.ShouldBe(1.14384);
            candles.Close.ShouldBe(1.143865);
            candles.Min.ShouldBe(1.14384);
            candles.Max.ShouldBe(1.143865);
        }

        [Fact]
        public void GetCandlesResult_WithFromAndTo_DateTimeMustSetCorrectly() {

            //act
            var result = JsonConvert.DeserializeObject<GetCandleItemsResultMessage>(GetCandlesSuccessJson);


            //assert
            result.Message.Infos.ShouldNotBeEmpty();

            var candles = result.Message.Infos.FirstOrDefault(x => x.Id == 17990335);

            var from = DateTimeOffset.FromUnixTimeSeconds(1534539516).ToLocalTime();

            candles.From.ShouldBe(from);
        }


        [Fact]
        public void GetCandlesResult_WithSuccessFul_ResultMustReturnSuccess() {
            //arrange

            //act
            var result = JsonConvert.DeserializeObject<GetCandleItemsResultMessage>(GetCandlesSuccessJson);


            //assert
            result.ShouldNotBeNull();
            result.Message.ShouldNotBeNull();
            result.Message.Count.ShouldBe(100);
        }
    }
}
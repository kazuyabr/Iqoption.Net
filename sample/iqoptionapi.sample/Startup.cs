using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using IqOptionApi;
using IqOptionApi.Models;
using Serilog;

namespace iqoptionapi.sample {
    public class Startup {
        private readonly IIqOptionApi _api;
        private readonly ILogger _logger;

        public Startup(IIqOptionApi api, Serilog.ILogger logger) {
            _api = api;
            _logger = logger;
        }

        public async Task RunSample() {

            if (await _api.ConnectAsync()) {
                _logger.Information("Connect Success");

                //get profile
                var profile = await _api.GetProfileAsync();


                // open order EurUsd in smallest period (1min) 
                var exp = DateTime.Now.AddMinutes(1);
                var buyResult = await _api.BuyAsync(ActivePair.EURUSD, 1, OrderDirection.Call, exp);
                

                // get candles data
                var candles = await _api.GetCandlesAsync(ActivePair.EURUSD, TimeFrame.Min1, 100, DateTimeOffset.Now);
                _logger.Information($"CandleCollections received {candles.Count}");

                
                // subscribe to pair to get real-time data for tf1min and tf5min
                var streamMin1 = await _api.SubscribeRealtimeDataAsync(ActivePair.EURUSD, TimeFrame.Min1);
                var streamMin5 = await _api.SubscribeRealtimeDataAsync(ActivePair.EURUSD, TimeFrame.Min5);

                streamMin5.Merge(streamMin1)
                    .Subscribe(candleInfo => {
                        _logger.Information($"Now {ActivePair.EURUSD} {candleInfo.TimeFrame} : Bid={candleInfo.Bid}\t Ask={candleInfo.Ask}\t");
                });

                // after this line no-more realtime data for min5 print on console
                await _api.UnSubscribeRealtimeData(ActivePair.EURUSD, TimeFrame.Min5);

               
                //when price down with 

            }
            


        }
    }
}
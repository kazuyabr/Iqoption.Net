using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IqOptionApi;
using IqOptionApi.Models;

namespace iqoptionapi.sample
{
    public class TradingForexExample {
        public TradingForexExample() { }

        public async Task RunSample() {


            var api = new IqOptionApi.IqOptionApi("mongkon.eiadon@gmail.com", "Code11054");

            var exp = DateTime.Now.AddMinutes(1);
            var buyResult = await api.BuyAsync(ActivePair.EURUSD, 1, OrderDirection.Call, exp);
        }
    }
}

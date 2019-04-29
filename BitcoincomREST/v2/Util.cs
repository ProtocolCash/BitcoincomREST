using System;
using System.Net.Http;
using System.Threading.Tasks;
using BitcoincomREST.v2.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BitcoincomREST.v2
{
    public static class Util
    {
        public static async Task<ValidatedAddress> ValidateAddressAsync(string address)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("util/validateAddress/" + address, RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<ValidatedAddress>(ret.body);
        }

        // NOTE: this function is broken on rest.bitcoin.com - it yields the first result multiple times
        public static async Task<ValidatedAddress[]> ValidateAddressesAsync(string[] addresses)
        {
            var request = new BitcoincomRequestHandler();
            var jsonBody = new JObject(new JProperty("addresses", JArray.FromObject(addresses)));
            var ret = await request.MakeRequest("util/validateAddress", RequestMethod.POST, jsonBody);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<ValidatedAddress[]>(ret.body);
        }

        public static ValidatedAddress ValidateAddress(string address, int timeout)
        {
            var task = ValidateAddressAsync(address);
            task.Wait(timeout);
            return task.Result;
        }

        // NOTE: this function is broken on rest.bitcoin.com - it yields the first result multiple times
        public static ValidatedAddress[] ValidateAddresses(string[] addresses, int timeout)
        {
            var task = ValidateAddressesAsync(addresses);
            task.Wait(timeout);
            return task.Result;
        }
    }
}
using System.Net.Http;
using System.Threading.Tasks;
using BitcoincomREST.v2.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BitcoincomREST.v2
{
    public static class Address
    {
        public static AddressDetails GetDetails(string address, int timeout)
        {
            var task = GetDetailsAsync(address);
            task.Wait(timeout);
            return task.Result;
        }

        public static AddressDetails[] GetDetails(string[] addresses, int timeout)
        {
            var task = GetDetailsAsync(addresses);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<AddressDetails> GetDetailsAsync(string address)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("address/details/" + address, RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<AddressDetails>(ret.body);
        }

        public static async Task<AddressDetails[]> GetDetailsAsync(string[] addresses)
        {
            var request = new BitcoincomRequestHandler();
            var jsonBody = new JObject(new JProperty("addresses", JArray.FromObject(addresses)));
            var ret = await request.MakeRequest("address/details", RequestMethod.POST, jsonBody);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<AddressDetails[]>(ret.body);
        }

        public static Transactions GetTransactions(string address, int timeout, int page = 0)
        {
            var task = GetTransactionsAsync(address, page);
            task.Wait(timeout);
            return task.Result;
        }

        public static Transactions[] GetTransactions(string[] addresses, int timeout)
        {
            var task = GetTransactionsAsync(addresses);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<Transactions> GetTransactionsAsync(string address, int page = 0)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("address/transactions/" + address + "?page=" + page, RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<Transactions>(ret.body);
        }

        public static async Task<Transactions[]> GetTransactionsAsync(string[] addresses)
        {
            var request = new BitcoincomRequestHandler();
            var jsonBody = new JObject(new JProperty("addresses", JArray.FromObject(addresses)));
            var ret = await request.MakeRequest("address/transactions", RequestMethod.POST, jsonBody);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<Transactions[]>(ret.body);
        }

        public static UTXOs GetUnconfirmedTransactions(string address, int timeout)
        {
            var task = GetUnconfirmedTransactionsAsync(address);
            task.Wait(timeout);
            return task.Result;
        }

        public static UTXOs[] GetUnconfirmedTransactions(string[] addresses, int timeout)
        {
            var task = GetUnconfirmedTransactionsAsync(addresses);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<UTXOs> GetUnconfirmedTransactionsAsync(string address)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("address/unconfirmed/" + address, RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<UTXOs>(ret.body);
        }

        public static async Task<UTXOs[]> GetUnconfirmedTransactionsAsync(string[] addresses)
        {
            var request = new BitcoincomRequestHandler();
            var jsonBody = new JObject(new JProperty("addresses", JArray.FromObject(addresses)));
            var ret = await request.MakeRequest("address/unconfirmed", RequestMethod.POST, jsonBody);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<UTXOs[]>(ret.body);
        }

        public static UTXOs GetUTXOs(string address, int timeout)
        {
            var task = GetUTXOsAsync(address);
            task.Wait(timeout);
            return task.Result;
        }

        public static UTXOs[] GetUTXOs(string[] addresses, int timeout)
        {
            var task = GetUTXOsAsync(addresses);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<UTXOs> GetUTXOsAsync(string address)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("address/utxo/" + address, RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<UTXOs>(ret.body);
        }

        public static async Task<UTXOs[]> GetUTXOsAsync(string[] addresses)
        {
            var request = new BitcoincomRequestHandler();
            var jsonBody = new JObject(new JProperty("addresses", JArray.FromObject(addresses)));
            var ret = await request.MakeRequest("address/utxo", RequestMethod.POST, jsonBody);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<UTXOs[]>(ret.body);
        }
    }
}
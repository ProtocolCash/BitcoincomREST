using System.Net.Http;
using System.Threading.Tasks;
using BitcoincomREST.v2.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BitcoincomREST.v2
{
    public static class RawTransactions
    {
        public static bool BroadcastRawTransaction(string rawTransactionHex, int timeout)
        {
            var task = BroadcastRawTransactionAsync(rawTransactionHex);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<bool> BroadcastRawTransactionAsync(string rawTransactionHex)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("rawtransactions/sendRawTransaction/" + rawTransactionHex, RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return true;
        }

        public static bool BroadcastRawTransactions(string[] rawTransactionsHex, int timeout)
        {
            var task = BroadcastRawTransactionsAsync(rawTransactionsHex);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<bool> BroadcastRawTransactionsAsync(string[] rawTransactionsHex)
        {
            var request = new BitcoincomRequestHandler();
            var jsonBody = new JObject(new JProperty("hexes", JArray.FromObject(rawTransactionsHex)));
            var ret = await request.MakeRequest("rawtransactions/sendRawTransaction", RequestMethod.POST, jsonBody);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return true;
        }

        public static TransactionInfo DecodeRawTransaction(string rawTransactionHex, int timeout)
        {
            var task = DecodeRawTransactionAsync(rawTransactionHex);
            task.Wait(timeout);
            return task.Result;
        }


        public static async Task<TransactionInfo> DecodeRawTransactionAsync(string rawTransactionHex)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("rawtransactions/decodeRawTransaction/" + rawTransactionHex, RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<TransactionInfo>(ret.body);
        }

        public static TransactionInfo[] DecodeRawTransactions(string[] rawTransactionsHex, int timeout)
        {
            var task = DecodeRawTransactionsAsync(rawTransactionsHex);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<TransactionInfo[]> DecodeRawTransactionsAsync(string[] rawTransactionsHex)
        {
            var request = new BitcoincomRequestHandler();
            var jsonBody = new JObject(new JProperty("hexes", JArray.FromObject(rawTransactionsHex)));
            var ret = await request.MakeRequest("rawtransactions/decodeRawTransaction", RequestMethod.POST, jsonBody);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<TransactionInfo[]>(ret.body);
        }

        public static ScriptInfo DecodeScript(string scriptHex, int timeout)
        {
            var task = DecodeScriptAsync(scriptHex);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<ScriptInfo> DecodeScriptAsync(string scriptHex)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("rawtransactions/decodeScript/" + scriptHex, RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<ScriptInfo>(ret.body);
        }

        public static ScriptInfo[] DecodeScripts(string[] scriptHex, int timeout)
        {
            var task = DecodeScriptsAsync(scriptHex);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<ScriptInfo[]> DecodeScriptsAsync(string[] scriptsHex)
        {
            var request = new BitcoincomRequestHandler();
            var jsonBody = new JObject(new JProperty("hexes", JArray.FromObject(scriptsHex)));
            var ret = await request.MakeRequest("rawtransactions/decodeScript", RequestMethod.POST, jsonBody);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<ScriptInfo[]>(ret.body);
        }

        public static string GetRawTransaction(string transactionHash, int timeout)
        {
            var task = GetRawTransactionAsync(transactionHash);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<string> GetRawTransactionAsync(string transactionHash)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("rawtransactions/getRawTransaction/" + transactionHash + "?verbose=false", RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<string>(ret.body);
        }

        public static RawTransactionInfo GetRawTransactionInfo(string transactionHash, int timeout)
        {
            var task = GetRawTransactionInfoAsync(transactionHash);
            task.Wait(timeout);
            return task.Result;
        }

        public static RawTransactionInfo[] GetRawTransactionInfo(string[] transactionHashes, int timeout)
        {
            var task = GetRawTransactionInfoAsync(transactionHashes);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<RawTransactionInfo> GetRawTransactionInfoAsync(string transactionHash)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("rawtransactions/getRawTransaction/" + transactionHash + "?verbose=true", RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<RawTransactionInfo>(ret.body);
        }

        public static async Task<RawTransactionInfo[]> GetRawTransactionInfoAsync(string[] transactionHashes)
        {
            var request = new BitcoincomRequestHandler();
            var jsonBody = new JObject(new JProperty("txids", JArray.FromObject(transactionHashes)), new JProperty("verbose", true));
            var ret = await request.MakeRequest("rawtransactions/getRawTransaction", RequestMethod.POST, jsonBody);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<RawTransactionInfo[]>(ret.body);
        }

        public static string[] GetRawTransactions(string[] transactionHashes, int timeout)
        {
            var task = GetRawTransactionsAsync(transactionHashes);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<string[]> GetRawTransactionsAsync(string[] transactionHashes)
        {
            var request = new BitcoincomRequestHandler();
            var jsonBody = new JObject(new JProperty("hexes", JArray.FromObject(transactionHashes)), new JProperty("verbose", false));
            var ret = await request.MakeRequest("rawtransactions/getRawTransaction", RequestMethod.POST, jsonBody);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<string[]>(ret.body);
        }
    }
}
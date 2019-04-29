using System.Net.Http;
using System.Threading.Tasks;
using BitcoincomREST.v2.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BitcoincomREST.v2
{
    public static class Transaction
    {
        public static TransactionInfo2 GetTransactionInfo(string transactionHash, int timeout)
        {
            var task = GetTransactionInfoAsync(transactionHash);
            task.Wait(timeout);
            return task.Result;
        }

        public static TransactionInfo2[] GetTransactionInfo(string[] transactionHashes, int timeout)
        {
            var task = GetTransactionInfoAsync(transactionHashes);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<TransactionInfo2> GetTransactionInfoAsync(string transactionHash)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("transaction/details/" + transactionHash, RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<TransactionInfo2>(ret.body);
        }

        public static async Task<TransactionInfo2[]> GetTransactionInfoAsync(string[] transactionHashes)
        {
            var request = new BitcoincomRequestHandler();
            var jsonBody = new JObject(new JProperty("txids", JArray.FromObject(transactionHashes)));
            var ret = await request.MakeRequest("transaction/details", RequestMethod.POST, jsonBody);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<TransactionInfo2[]>(ret.body);
        }
    }
}
using System.Net.Http;
using System.Threading.Tasks;
using BitcoincomREST.v2.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BitcoincomREST.v2
{
    public static class Block
    {
        public static BlockDetails GetDetailsByHash(string blockHash, int timeout)
        {
            var task = GetDetailsByHashAsync(blockHash);
            task.Wait(timeout);
            return task.Result;
        }

        public static BlockDetails[] GetDetailsByHash(string[] blockHashes, int timeout)
        {
            var task = GetDetailsByHashAsync(blockHashes);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<BlockDetails> GetDetailsByHashAsync(string blockHash)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("block/detailsByHash/" + blockHash, RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<BlockDetails>(ret.body);
        }

        public static async Task<BlockDetails[]> GetDetailsByHashAsync(string[] blockHashes)
        {
            var request = new BitcoincomRequestHandler();
            var jsonBody = new JObject(new JProperty("hashes", JArray.FromObject(blockHashes)));
            var ret = await request.MakeRequest("block/detailsByHash", RequestMethod.POST, jsonBody);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<BlockDetails[]>(ret.body);
        }

        public static BlockDetails GetDetailsByHeight(int blockHeight, int timeout)
        {
            var task = GetDetailsByHeightAsync(blockHeight);
            task.Wait(timeout);
            return task.Result;
        }

        public static BlockDetails[] GetDetailsByHeight(int[] blockHeights, int timeout)
        {
            var task = GetDetailsByHeightAsync(blockHeights);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<BlockDetails> GetDetailsByHeightAsync(int blockHeight)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("block/detailsByHeight/" + blockHeight, RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<BlockDetails>(ret.body);
        }

        public static async Task<BlockDetails[]> GetDetailsByHeightAsync(int[] blockHeights)
        {
            var request = new BitcoincomRequestHandler();
            var jsonBody = new JObject(new JProperty("heights", JArray.FromObject(blockHeights)));
            var ret = await request.MakeRequest("block/detailsByHeight", RequestMethod.POST, jsonBody);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<BlockDetails[]>(ret.body);
        }
    }
}
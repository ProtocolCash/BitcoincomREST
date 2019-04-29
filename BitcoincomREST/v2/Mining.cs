using System;
using System.Net.Http;
using System.Threading.Tasks;
using BitcoincomREST.v2.Model;
using Newtonsoft.Json;

namespace BitcoincomREST.v2
{
    public class Mining
    {
        public static MiningInfo GetMiningInfo(int timeout)
        {
            var task = GetMiningInfoAsync();
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<MiningInfo> GetMiningInfoAsync()
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("mining/getMiningInfo", RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<MiningInfo>(ret.body);
        }

        public static ulong GetNetworkHashPerSecond(int timeout, int nBlocks = 120, int height = -1)
        {
            var task = GetNetworkHashPerSecondAsync(nBlocks, height);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<ulong> GetNetworkHashPerSecondAsync(int nBlocks = 120, int height = -1)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("mining/getNetworkHashps?nblocks=" + nBlocks + "&height=" + height,
                RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return Convert.ToUInt64(ret.body);
        }
    }
}
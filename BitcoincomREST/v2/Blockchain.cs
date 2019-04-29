using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BitcoincomREST.v2.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BitcoincomREST.v2
{
    public static class Blockchain
    {
        public static Dictionary<string, MempoolEntryInfo> GetAllMempoolEntries(int timeout)
        {
            var task = GetAllMempoolEntriesAsync();
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<Dictionary<string, MempoolEntryInfo>> GetAllMempoolEntriesAsync()
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("blockchain/getRawMempool?verbose=true", RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<Dictionary<string, MempoolEntryInfo>>(ret.body);
        }

        public static string[] GetAllMempoolEntryIds(int timeout)
        {
            var task = GetAllMempoolEntryIdsAsync();
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<string[]> GetAllMempoolEntryIdsAsync()
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("blockchain/getRawMempool?verbose=false", RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<string[]>(ret.body);
        }

        public static string GetBestBlockHash(int timeout)
        {
            var task = GetBestBlockHashAsync();
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<string> GetBestBlockHashAsync()
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("blockchain/getBestBlockHash", RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<string>(ret.body);
        }

        public static BlockchainInfo GetBlockChainInfo(int timeout)
        {
            var task = GetBlockChainInfoAsync();
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<BlockchainInfo> GetBlockChainInfoAsync()
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("blockchain/getBlockchainInfo", RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<BlockchainInfo>(ret.body);
        }

        public static int GetBlockCount(int timeout)
        {
            var task = GetBlockCountAsync();
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<int> GetBlockCountAsync()
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("blockchain/getBlockCount", RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<int>(ret.body);
        }

        public static BlockHeader GetBlockHeader(string blockHash, int timeout)
        {
            var task = GetBlockHeaderAsync(blockHash);
            task.Wait(timeout);
            return task.Result;
        }

        public static BlockHeader[] GetBlockHeader(string[] blockHashes, int timeout)
        {
            var task = GetBlockHeaderAsync(blockHashes);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<BlockHeader> GetBlockHeaderAsync(string blockHash)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("blockchain/getBlockHeader/" + blockHash + "?verbose=true",
                RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<BlockHeader>(ret.body);
        }

        public static async Task<BlockHeader[]> GetBlockHeaderAsync(string[] blockHashes)
        {
            var request = new BitcoincomRequestHandler();
            var jsonBody = new JObject(new JProperty("hashes", JArray.FromObject(blockHashes)),
                new JProperty("verbose", true));
            var ret = await request.MakeRequest("blockchain/getBlockHeader", RequestMethod.POST, jsonBody);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<BlockHeader[]>(ret.body);
        }

        public static ChainTip[] GetChainTips(int timeout)
        {
            var task = GetChainTipsAsync();
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<ChainTip[]> GetChainTipsAsync()
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("blockchain/getChainTips", RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<ChainTip[]>(ret.body);
        }

        public static double GetDifficulty(int timeout)
        {
            var task = GetDifficultyAsync();
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<double> GetDifficultyAsync()
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("blockchain/getDifficulty", RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<double>(ret.body);
        }

        public static MempoolEntryInfo GetMempoolEntry(string transactionHash, int timeout)
        {
            var task = GetMempoolEntryAsync(transactionHash);
            task.Wait(timeout);
            return task.Result;
        }

        public static MempoolEntryInfo[] GetMempoolEntry(string[] transactionHashes, int timeout)
        {
            var task = GetMempoolEntryAsync(transactionHashes);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<MempoolEntryInfo> GetMempoolEntryAsync(string transactionHash)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("blockchain/getMempoolEntry/" + transactionHash, RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<MempoolEntryInfo>(ret.body);
        }

        public static async Task<MempoolEntryInfo[]> GetMempoolEntryAsync(string[] transactionHashes)
        {
            var request = new BitcoincomRequestHandler();
            var jsonBody = new JObject(new JProperty("txids", JArray.FromObject(transactionHashes)));
            var ret = await request.MakeRequest("blockchain/getMempoolEntry", RequestMethod.POST, jsonBody);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<MempoolEntryInfo[]>(ret.body);
        }

        public static MempoolInfo GetMempoolInfo(int timeout)
        {
            var task = GetMempoolInfoAsync();
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<MempoolInfo> GetMempoolInfoAsync()
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("blockchain/getMempoolInfo", RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<MempoolInfo>(ret.body);
        }

        public static string GetRawBlockHeader(string blockHash, int timeout)
        {
            var task = GetRawBlockHeaderAsync(blockHash);
            task.Wait(timeout);
            return task.Result;
        }

        public static string[] GetRawBlockHeader(string[] blockHashes, int timeout)
        {
            var task = GetRawBlockHeaderAsync(blockHashes);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<string> GetRawBlockHeaderAsync(string blockHash)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("blockchain/getBlockHeader/" + blockHash + "?verbose=false",
                RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<string>(ret.body);
        }

        public static async Task<string[]> GetRawBlockHeaderAsync(string[] blockHashes)
        {
            var request = new BitcoincomRequestHandler();
            var jsonBody = new JObject(new JProperty("hashes", JArray.FromObject(blockHashes)),
                new JProperty("verbose", false));
            var ret = await request.MakeRequest("blockchain/getBlockHeader", RequestMethod.POST, jsonBody);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<string[]>(ret.body);
        }

        public static TxOutInfo GetTxOut(string transactionHash, int vOut, int timeout, bool includeMempool)
        {
            var task = GetTxOutAsync(transactionHash, vOut, includeMempool);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<TxOutInfo> GetTxOutAsync(string transactionHash, int vOut, bool includeMempool)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("blockchain/getTxOut/" + transactionHash + "/" +
                                                vOut + "?mempool=" + (includeMempool ? "true" : "false"),
                RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<TxOutInfo>(ret.body);
        }

        public static string GetTxOutProof(string transactionHash, int timeout)
        {
            var task = GetTxOutProofAsync(transactionHash);
            task.Wait(timeout);
            return task.Result;
        }

        public static string[] GetTxOutProof(string[] transactionHashes, int timeout)
        {
            var task = GetTxOutProofAsync(transactionHashes);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<string> GetTxOutProofAsync(string transactionHash)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("blockchain/getTxOutProof/" + transactionHash, RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<string>(ret.body);
        }

        public static async Task<string[]> GetTxOutProofAsync(string[] transactionHashes)
        {
            var request = new BitcoincomRequestHandler();
            var jsonBody = new JObject(new JProperty("txids", JArray.FromObject(transactionHashes)));
            var ret = await request.MakeRequest("blockchain/getTxOutProof", RequestMethod.POST, jsonBody);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<string[]>(ret.body);
        }

        public static string[] VerifyTxOutProof(string proofHash, int timeout)
        {
            var task = VerifyTxOutProofAsync(proofHash);
            task.Wait(timeout);
            return task.Result;
        }

        public static string[] VerifyTxOutProof(string[] proofHashes, int timeout)
        {
            var task = VerifyTxOutProofAsync(proofHashes);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<string[]> VerifyTxOutProofAsync(string hexProof)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("blockchain/verifyTxOutProof/" + hexProof, RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<string[]>(ret.body);
        }

        public static async Task<string[]> VerifyTxOutProofAsync(string[] hexProofs)
        {
            var request = new BitcoincomRequestHandler();
            var jsonBody = new JObject(new JProperty("proofs", JArray.FromObject(hexProofs)));
            var ret = await request.MakeRequest("blockchain/verifyTxOutProof", RequestMethod.POST, jsonBody);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<string[]>(ret.body);
        }
    }
}
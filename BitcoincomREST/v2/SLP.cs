using System;
using System.Net.Http;
using System.Threading.Tasks;
using BitcoincomREST.v2.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BitcoincomREST.v2
{
    public class SLP
    {
        public static SLPTokenInfo[] GetAllSLPTokensInfo(int timeout)
        {
            var task = GetAllSLPTokensInfoAsync();
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<SLPTokenInfo[]> GetAllSLPTokensInfoAsync()
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("slp/list", RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<SLPTokenInfo[]>(ret.body);
        }

        public static TokenBalanceInfo3 GetBalance(string tokenId, string address, int timeout)
        {
            var task = GetBalanceAsync(tokenId, address);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<TokenBalanceInfo3> GetBalanceAsync(string tokenId, string address)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("slp/balance/" + address + "/" + tokenId, RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<TokenBalanceInfo3>(ret.body);
        }
        
        public static TokenBalanceInfo2[] GetBalancesForAddress(string address, int timeout)
        {
            var task = GetBalancesForAddressAsync(address);
            task.Wait(timeout);
            return task.Result;
        }
        
        public static async Task<TokenBalanceInfo2[]> GetBalancesForAddressAsync(string address)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("slp/balancesForAddress/" + address, RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<TokenBalanceInfo2[]>(ret.body);
        }

        public static TokenBalanceInfo[] GetBalancesForToken(string tokenId, int timeout)
        {
            var task = GetBalancesForTokenAsync(tokenId);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<TokenBalanceInfo[]> GetBalancesForTokenAsync(string tokenId)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("slp/balancesForToken/" + tokenId, RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<TokenBalanceInfo[]>(ret.body);
        }

        public static SLPTokenInfo GetSLPTokenInfo(string tokenId, int timeout)
        {
            var task = GetSLPTokenInfoAsync(tokenId);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<SLPTokenInfo> GetSLPTokenInfoAsync(string tokenId)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("slp/list/" + tokenId, RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<SLPTokenInfo>(ret.body);
        }

        public static SLPTokenInfo[] GetSLPTokensInfo(string[] tokenIds, int timeout)
        {
            var task = GetSLPTokensInfoAsync(tokenIds);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<SLPTokenInfo[]> GetSLPTokensInfoAsync(string[] tokenIds)
        {
            var request = new BitcoincomRequestHandler();
            var jsonBody = new JObject(new JProperty("tokenIds", JArray.FromObject(tokenIds)));
            var ret = await request.MakeRequest("slp/list", RequestMethod.POST, jsonBody);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<SLPTokenInfo[]>(ret.body);
        }

        public static SLPTransactionInfo GetTransaction(string transactionHash, int timeout)
        {
            var task = GetTransactionAsync(transactionHash);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<SLPTransactionInfo> GetTransactionAsync(string transactionHash)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("slp/txDetails/" + transactionHash, RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<SLPTransactionInfo>(ret.body);
        }

        public static ValidatedTxid ValidateTxid(string transactionHash, int timeout)
        {
            var task = ValidateTxidAsync(transactionHash);
            task.Wait(timeout);
            return task.Result;
        }

        public static ValidatedTxid[] ValidateTxids(string[] transactionHash, int timeout)
        {
            var task = ValidateTxidsAsync(transactionHash);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<ValidatedTxid> ValidateTxidAsync(string transactionHash)
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("slp/validateTxid/" + transactionHash, RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<ValidatedTxid>(ret.body);
        }

        public static async Task<ValidatedTxid[]> ValidateTxidsAsync(string[] transactionHashes)
        {
            var request = new BitcoincomRequestHandler();
            var jsonBody = new JObject(new JProperty("txids", JArray.FromObject(transactionHashes)));
            var ret = await request.MakeRequest("slp/validateTxid", RequestMethod.POST, jsonBody);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int)ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<ValidatedTxid[]>(ret.body);
        }

        // returns same result with slp/tokenstats as slp/list/... so, not needed
        /*
        public static SLPTokenInfo GetTokenStats(string tokenId, int timeout)
        {
            var task = GetTokenStatsAsync(tokenId);
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<SLPTokenInfo> GetTokenStatsAsync(string tokenId)
        {
            throw new NotImplementedException();
        }
        */
    }
}
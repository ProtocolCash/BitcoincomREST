using System;
using BitcoincomREST.v2.Model;

namespace BitcoincomREST.v2
{
    public class SLP
    {
        public static SLPTokenInfo[] GetAllSLPTokensInfo()
        {
            throw new NotImplementedException();
        }

        public static SLPTokenInfo[] GetSLPTokensInfo(string[] tokenIds)
        {
            throw new NotImplementedException();
        }

        public static SLPTokenInfo GetSLPTokenInfo(string tokenId)
        {
            return GetSLPTokensInfo(new[] {tokenId})[0];
        }

        // this is not TokenBalanceInfo ... looks like slightly different
        public static TokenBalanceInfo[] GetBalancesForAddress(string address)
        {
            throw new NotImplementedException();
        }

        public static TokenBalanceInfo[] GetBalancesForToken(string tokenId)
        {
            throw new NotImplementedException();
        }

        public static TokenBalanceInfo3[] GetBalance(string tokenId, string address)
        {
            throw new NotImplementedException();
        }

        public static ValidatedTxid ValidateTxid(string transactionHash)
        {
            throw new NotImplementedException();
        }

        public static ValidatedTxid[] ValidateTxid(string[] transactionHash)
        {
            throw new NotImplementedException();
        }

        /*
        public static SLPTransactionInfo[] GetTransaction(string tokenId)
        {
            throw new NotImplementedException();
        }

        public static Dictionary<string, SLPTokenDetails> GetTransactions(string tokenId)
        {
            throw new NotImplementedException();
        }
        */
    }
}
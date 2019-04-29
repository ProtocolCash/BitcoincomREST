using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class TokenBalanceInfo
    {
        [JsonProperty("tokenBalance")]
        public double TokenBalance;
        [JsonProperty("slpAddress")]
        public string SLPAddress;
        [JsonProperty("tokenId")]
        public string TokenId;
    }

    [JsonObject]
    public class TokenBalanceInfo3
    {
        [JsonProperty("balance")]
        public double balance;
        [JsonProperty("tokenId")]
        public string TokenId;
    }
}
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
    public class TokenBalanceInfo2 : TokenBalanceInfo3
    {
        [JsonProperty("slpAddress")]
        public string SLPAddress;
        [JsonProperty("decimalCount")]
        public int DecimalCount;
    }

    [JsonObject]
    public class TokenBalanceInfo3
    {
        [JsonProperty("balance")]
        public double Balance;
        [JsonProperty("tokenId")]
        public string TokenId;
    }
}
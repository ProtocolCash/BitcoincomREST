using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class TxOutInfo
    {
        [JsonProperty("bestblock")]
        public string BestBlock;
        [JsonProperty("confirmations")]
        public int Confirmations;
        [JsonProperty("value")]
        public double Value;
        [JsonProperty("scriptPubKey")]
        public ScriptPubKey ScriptPubKey;
        [JsonProperty("coinbase")]
        public bool CoinBase;
    }
}
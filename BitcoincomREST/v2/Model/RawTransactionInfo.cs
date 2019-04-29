using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class RawTransactionInfo : TransactionInfo
    {
        [JsonProperty("hex")]
        public string Hex;

        // ...

        [JsonProperty("blockhash")]
        public string BlockHash;
        [JsonProperty("confirmations")]
        public int Confirmations;
        [JsonProperty("time")]
        public long Time;
        [JsonProperty("blocktime")]
        public long BlockTime;
    }
}
using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class UTXO
    {
        [JsonProperty("txid")]
        public string TXID;
        [JsonProperty("vout")]
        public int VOut;
        [JsonProperty("amount")]
        public double Amount;
        [JsonProperty("satoshis")]
        public long Satoshis;
        [JsonProperty("height")]
        public int Height;
        [JsonProperty("confirmations")]
        public int Confirmations;
    }
}
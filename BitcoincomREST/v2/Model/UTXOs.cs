using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class UTXOs
    {
        [JsonProperty("utxos")]
        public UTXO[] UTXO;
        [JsonProperty("legacyAddress")]
        public string LegacyAddress;
        [JsonProperty("cashAddress")]
        public string CashAddress;
        [JsonProperty("scriptPubKey")]
        public string ScriptPubKey;
    }
}
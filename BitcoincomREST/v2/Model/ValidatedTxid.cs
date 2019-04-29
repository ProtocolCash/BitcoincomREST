using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class ValidatedTxid
    {
        [JsonProperty("txid")]
        public string Txid;
        [JsonProperty("valid")]
        public bool Valid;
    }
}
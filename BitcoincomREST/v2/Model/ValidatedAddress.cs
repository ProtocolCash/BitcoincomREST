using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class ValidatedAddress
    {
        [JsonProperty("isvalid")]
        public bool IsValid;
        [JsonProperty("address")]
        public string Address;
        [JsonProperty("scriptPubKey")]
        public string ScriptPubKey;
        [JsonProperty("ismine")]
        public bool IsMine;
        [JsonProperty("iswatchonly")]
        public bool IsWatchOnly;
        [JsonProperty("isscript")]
        public bool IsScript;
    }
}
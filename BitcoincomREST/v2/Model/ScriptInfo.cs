using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class ScriptInfo
    {
        [JsonProperty("asm")]
        public string Asm;
        [JsonProperty("type")]
        public string Type;
        [JsonProperty("p2sh")]
        public string P2SH;
        [JsonProperty("addresses")]
        public string[] Addresses;
    }
}
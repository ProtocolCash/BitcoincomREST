using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class ScriptSig
    {
        [JsonProperty("asm")]
        public string Script;
        [JsonProperty("hex")]
        public string Hex;
    }
}
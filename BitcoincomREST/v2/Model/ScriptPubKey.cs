using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class ScriptPubKey
    {
        [JsonProperty("asm")]
        public string ScriptAsm;
        [JsonProperty("hex")]
        public string Hex;
        [JsonProperty("reqSigs")]
        public int RegSigs;
        [JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type;
        [JsonProperty("addresses")]
        public string[] Addresses;
        [JsonProperty("cashAddrs")]
        public string[] CashAddresses;
    }
}
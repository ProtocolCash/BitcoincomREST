using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class ControlInfo
    {
        [JsonProperty("version")]
        public int Version;
        [JsonProperty("protocolversion")]
        public int ProtocolVersion;
        [JsonProperty("blocks")]
        public int Blocks;
        [JsonProperty("timeoffset")]
        public int TimeOffset;
        [JsonProperty("connections")]
        public int Connections;
        [JsonProperty("proxy")]
        public string Proxy;
        [JsonProperty("difficulty")]
        public double Difficulty;
        [JsonProperty("testnet")]
        public bool TestNet;
        [JsonProperty("paytxfee")]
        public double PayTxFee;
        [JsonProperty("relayfee")]
        public double RelayFee;
        [JsonProperty("errors")]
        public string Errors;
    }
}
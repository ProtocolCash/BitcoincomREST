using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class MempoolInfo
    {
        [JsonProperty("size")]
        public int Size;
        [JsonProperty("bytes")]
        public int Bytes;
        [JsonProperty("usage")]
        public int Usage;
        [JsonProperty("maxmempool")]
        public int MaxMempool;
        [JsonProperty("mempoolminfee")]
        public int MempoolMinFee;
    }
}
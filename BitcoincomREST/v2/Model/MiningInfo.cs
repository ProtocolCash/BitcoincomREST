using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class MiningInfo
    {
        [JsonProperty("blocks")]
        public int Blocks;
        [JsonProperty("currentblocksize")]
        public int CurrentBlockSize;
        [JsonProperty("currentblocktx")]
        public int CurrentBlockTx;
        [JsonProperty("difficulty")]
        public double Difficulty;
        [JsonProperty("blockprioritypercentage")]
        public int BlockPriorityPercentage;
        [JsonProperty("errors")]
        public string Errors;
        [JsonProperty("networkhashps")]
        public double NetworkHashPs;
        [JsonProperty("pooledtx")]
        public int PooledTx;
        [JsonProperty("chain")]
        public string Chain;
    }
}
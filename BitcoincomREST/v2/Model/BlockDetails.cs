using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class BlockDetails
    {
        [JsonProperty("hash")]
        public string Hash;
        [JsonProperty("size")]
        public int Size;
        [JsonProperty("height")]
        public int Height;
        [JsonProperty("version")]
        public long Version;
        [JsonProperty("merkleroot")]
        public string MerkleRoot;
        [JsonProperty("tx")]
        public string[] Tx;
        [JsonProperty("time")]
        public long Time;
        [JsonProperty("nonce")]
        public long Nonce;
        [JsonProperty("bits")]
        public string Bits;
        [JsonProperty("difficulty")]
        public double Difficulty;
        [JsonProperty("chainwork")]
        public string ChainWork;
        [JsonProperty("confirmations")]
        public int Confirmations;
        [JsonProperty("previousblockhash")]
        public string PreviousBlockHash;
        [JsonProperty("nextblockhash")]
        public string NextBlockHash;
        [JsonProperty("reward")]
        public double Reward;
        [JsonProperty("isMainChain")]
        public bool IsMainChain;
        [JsonProperty("poolInfo")]
        public PoolInfo PoolInfo;
    }

    public class PoolInfo
    {
        [JsonProperty("poolName")]
        public string PoolName;
        [JsonProperty("url")]
        public string URL;
    }
}
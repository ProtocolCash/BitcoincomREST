using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class BlockHeader
    {
        [JsonProperty("hash")]
        public string Hash;
        [JsonProperty("confirmations")]
        public int Confirmations;
        [JsonProperty("height")]
        public int Height;
        [JsonProperty("version")]
        public long Version;
        [JsonProperty("versionHex")]
        public string VersionHex;
        [JsonProperty("merkleroot")]
        public string MerkleRoot;
        [JsonProperty("time")]
        public long Time;
        [JsonProperty("mediantime")]
        public long MedianTime;
        [JsonProperty("nonce")]
        public long Nonce;
        [JsonProperty("bits")]
        public string Bits;
        [JsonProperty("difficulty")]
        public double Difficulty;
        [JsonProperty("chainwork")]
        public string ChainWork;
        [JsonProperty("previousblockhash")]
        public string PreviousBlockHash;
        [JsonProperty("nextblockhash")]
        public string NextBlockHash;
    }
}
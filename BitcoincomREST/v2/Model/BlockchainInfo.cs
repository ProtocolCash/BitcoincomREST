using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class BlockchainInfo
    {
        [JsonProperty("chain")]
        public string Chain;
        [JsonProperty("blocks")]
        public int Blocks;
        [JsonProperty("headers")]
        public int Headers;
        [JsonProperty("bestblockhash")]
        public string BestBlockHash;
        [JsonProperty("difficulty")]
        public double Difficulty;
        [JsonProperty("mediantime")]
        public long MedianTime;
        [JsonProperty("verificationprogress")]
        public double VerificationProcess;
        [JsonProperty("chainwork")]
        public string ChainWork;
        [JsonProperty("pruned")]
        public bool Pruned;
        [JsonProperty("softforks")]
        public SoftForkInfo[] SoftForks;
    }

    [JsonObject]
    public class SoftForkInfo
    {
        [JsonProperty("id")]
        public string Id;
        [JsonProperty("version")]
        public int Version;
        [JsonProperty("reject")]
        public SoftForkReject Reject;
    }

    public class SoftForkReject
    {
        [JsonProperty("status")]
        public bool Status;
    }

}
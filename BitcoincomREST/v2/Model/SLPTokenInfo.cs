using System.Numerics;
using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class SLPTokenInfo
    {
        [JsonProperty("decimals")]
        public int Decimals;
        [JsonProperty("timestamp")]
        public string Timestamp;
        [JsonProperty("versionType")]
        public int VersionType;
        [JsonProperty("documentUri")]
        public string DocumentUri;
        [JsonProperty("symbol")]
        public string Symbol;
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("containsBaton")]
        public bool ContainsBaton;
        [JsonProperty("id")]
        public string TokenId;
        [JsonProperty("documentHash")]
        public string DocumentHash;
        [JsonProperty("initialTokenQty")]
        public BigInteger InitialTokenQty;
        [JsonProperty("blockCreated")]
        public ulong? BlockCreated; // not sure why this is nullable...
        [JsonProperty("blockLastActiveSend")]
        public ulong? BlockLastActiveSend;
        [JsonProperty("blockLastActiveMint")]
        public ulong? BlockLastActiveMint;
        [JsonProperty("txnsSinceGenesis")]
        public ulong TxnsSinceGenesis;
        [JsonProperty("totalMinted")]
        public BigInteger TotalMinted;
        [JsonProperty("totalBurned")]
        public BigInteger TotalBurned;
        [JsonProperty("circulatingSupply")]
        public BigInteger CirculatingSupply;
        [JsonProperty("mintingBatonStatus")]
        public MintingBatonState MintingBatonStatus;

        public enum MintingBatonState
        {
            NEVER_CREATED,
            ALIVE,
            DEAD_BURNED,
            DEAD_ENDED
        }
    }
}
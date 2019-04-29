using System;
using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class SLPTokenStats
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
        public string Id;
        [JsonProperty("documentHash")]
        public string DocumentHash;
        [JsonProperty("initialTokenQty")]
        public long InitialTokenQty;
        [JsonProperty("blockCreated")]
        public int BlockCreated;
        [JsonProperty("")]
        public int BlockLastActiveSend;
        [JsonProperty("blockLastActiveSend")]
        public int? BlockLastActiveMint;
        [JsonProperty("blockLastActiveMint")]
        public long TransactionsSinceGenesis;
        [JsonProperty("txnsSinceGenesis")]
        public int ValidAddresses;
        [JsonProperty("validAddresses")]
        public int TotalMinted;
        [JsonProperty("totalMinted")]
        public double TotalBurned;
        [JsonProperty("totalBurned")]
        public double CirculatingSupply;
        [JsonProperty("mintingBatonStatus")]
        public string MintingBatonStatus;
    }
}
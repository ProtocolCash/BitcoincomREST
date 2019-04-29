using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BitcoincomREST.v2.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChainTipStatus
    {
        [EnumMember(Value = "active")]
        Active,
        [EnumMember(Value = "headers-only")]
        HeadersOnly,
        [EnumMember(Value = "valid-fork")]
        ValidFork,
        [EnumMember(Value = "valid-headers")]
        ValidHeaders,
        [EnumMember(Value = "invalid")]
        Invalid
    }

    [JsonObject]
    public class ChainTip
    {
        [JsonProperty("height")]
        public int Height;
        [JsonProperty("hash")]
        public string Hash;
        [JsonProperty("branchLength")]
        public int BranchLength;
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ChainTipStatus Status;
    }
}
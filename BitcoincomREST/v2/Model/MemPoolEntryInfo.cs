using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class MempoolEntryInfo
    {
        [JsonProperty("size")]
        public int Size;
        [JsonProperty("fee")]
        public double Fee;
        [JsonProperty("modifiedfee")]
        public double ModifiedFee;
        [JsonProperty("time")]
        public long Time;
        [JsonProperty("height")]
        public int Height;
        [JsonProperty("startingpriority")]
        public double StartingPriority;
        [JsonProperty("currentpriority")]
        public double CurrentPriority;
        [JsonProperty("descendantcount")]
        public int DescendantCount;
        [JsonProperty("descendantsize")]
        public int DescendantSize;
        [JsonProperty("descendantfees")]
        public int DescendantFees;
        [JsonProperty("ancestorcount")]
        public int AncestorCount;
        [JsonProperty("ancestorsize")]
        public int AncestorSize;
        [JsonProperty("ancestorfees")]
        public int AncestorFees;
        [JsonProperty("Depends")]
        public string[] Depends;
    }
}
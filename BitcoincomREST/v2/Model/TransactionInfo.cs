using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class TransactionInfo2
    {
        [JsonProperty("txid")]
        public string Txid;
        [JsonProperty("version")]
        public int Version;
        [JsonProperty("locktime")]
        public int LockTime;
        [JsonProperty("vin")]
        public TxInInfo[] Inputs;
        [JsonProperty("vout")]
        public TxOutInfo2[] Outputs;
        [JsonProperty("blockhash")]
        public string BlockHash;
        [JsonProperty("blockheight")]
        public int BlockHeight;
        [JsonProperty("confirmations")]
        public int Confirmations;
        [JsonProperty("time")]
        public int Time;
        [JsonProperty("blocktime")]
        public int BlockTime;
        [JsonProperty("isCoinBase")]
        public bool IsCoinBase;
        [JsonProperty("valueOut")]
        public double ValueOut;
        [JsonProperty("size")]
        public int Size;
        [JsonProperty("valueIn")]
        public double ValueIn;
        [JsonProperty("fees")]
        public double Fees;
    }

    [JsonObject]
    public class TransactionInfo
    {
        [JsonProperty("txid")]
        public string Txid;
        [JsonProperty("hash")]
        public string Hash;
        [JsonProperty("size")]
        public int Size;
        [JsonProperty("version")]
        public int Version;
        [JsonProperty("locktime")]
        public int LockTime;
        [JsonProperty("vin")]
        public TxInInfo[] Inputs;
        [JsonProperty("vout")]
        public TxOutInfo2[] Outputs;

    }

    [JsonObject]
    public class TxInInfo
    {
        [JsonProperty("coinbase", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Coinbase;
        [JsonProperty("n", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int N;
        [JsonProperty("txid", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Txid;
        [JsonProperty("vout", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int VOut;
        [JsonProperty("scriptSig", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ScriptSig ScriptSig;
        [JsonProperty("sequence", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long Sequence;

    }

    [JsonObject]
    public class TxOutInfo2
    {
        [JsonProperty("value")]
        public double Value;
        [JsonProperty("n")]
        public int Position;
        [JsonProperty("scriptPubKey")]
        public ScriptPubKey ScriptPubKey;
    }
}
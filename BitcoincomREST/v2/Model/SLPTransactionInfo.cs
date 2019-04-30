using System.Dynamic;
using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    public enum SLPMessageType
    {
        SEND,
        COMMIT,
        GENESIS,
        MINT
    }

    [JsonObject]
    public class SLPTransactionInfo
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
        public SLPTxOutInfo[] Outputs;
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
        [JsonProperty("tokenInfo")]
        // this can be several different message types... indicated by TransactionType param
        // TODO: handle MINT, COMMIT, GENESIS messages
        public SLPTransactionMessageInfo TokenInfo;
        [JsonProperty("tokenIsValid")]
        public bool TokenIsValid;
    }

    [JsonObject]
    public class SLPTransactionMessageInfo
    {
        [JsonProperty("versionType")]
        public uint VersionType;
        [JsonProperty("transactionType")]
        public SLPMessageType TransactionType;
        [JsonProperty("tokenIdHex")]
        public string TokenIdHex;
        [JsonProperty("sendOutputs")]
        public string[] SendOutputs;
    }

    public class SLPTxOutInfo
    {
        [JsonProperty("value")]
        public double Value;
        [JsonProperty("n")]
        public int Position;
        [JsonProperty("scriptPubKey")]
        public ScriptPubKey ScriptPubKey;
        [JsonProperty("spentTxId")]
        public string SpentTxId;
        [JsonProperty("spentIndex")]
        public uint? SpentIndex;
        [JsonProperty("spentHeight")]
        public ulong? SpentHeight;
    }
}
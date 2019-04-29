using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class AddressDetails
    {
        [JsonProperty("balance")]
        public double Balance;
        [JsonProperty("balanceSat")]
        public long BalanceSat;
        [JsonProperty("totalReceived")]
        public double TotalReceived;
        [JsonProperty("totalReceivedSat")]
        public long TotalReceivedSat;
        [JsonProperty("totalSent")]
        public double TotalSent;
        [JsonProperty("totalSentSat")]
        public double TotalSentSat;
        [JsonProperty("unconfirmedBalance")]
        public long UnconfirmedBalance;
        [JsonProperty("unconfirmedBalanceSat")]
        public long UnconfirmedBalanceSat;
        [JsonProperty("unconfirmedTxAppearances")]
        public long UnconfirmedTxAppearances;
        [JsonProperty("txAppearances")]
        public long TxAppearances;
        [JsonProperty("transactions")]
        public string[] Transactions;
        [JsonProperty("legacyAddress")]
        public string LegacyAddress;
        [JsonProperty("cashAddress")]
        public string CashAddress;
    }
}

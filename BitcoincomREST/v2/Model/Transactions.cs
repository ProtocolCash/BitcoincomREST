using Newtonsoft.Json;

namespace BitcoincomREST.v2.Model
{
    [JsonObject]
    public class Transactions
    {
        [JsonProperty("pagesTotal")]
        public int PagesTotal;
        [JsonProperty("txs")]
        public TransactionInfo[] Txs;
        [JsonProperty("legacyAddress")]
        public string LegacyAddress;
        [JsonProperty("cashAddress")]
        public string CashAddress;
        [JsonProperty("currentPage")]
        public int CurrentPage;
    }
}
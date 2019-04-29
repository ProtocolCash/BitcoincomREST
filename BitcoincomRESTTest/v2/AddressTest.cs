
using BitcoincomREST.v2;
using Xunit;

namespace BitcoincomRESTTest.v2
{
    public class AddressTest
    {
        private const int ResponseTimeOut = 30000;

        [Fact]
        public void GetDetailsShouldReturn()
        {
            // TODO: check all other variables, e.g. balance, balanceSat, totalReceived, totalReceivedSat, totalSent, etc
            var result = Address.GetDetails("bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c", ResponseTimeOut);

            Assert.Equal("bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c", result.CashAddress);
            Assert.Equal("1Fg4r9iDrEkCcDmHTy2T79EusNfhyQpu7W", result.LegacyAddress);
        }

        [Fact]
        public void GetDetailsMultiShouldReturn()
        {
            // TODO: check all other variables, e.g. balance, balanceSat, totalReceived, totalReceivedSat, totalSent, etc
            var result = Address.GetDetails(new[] {
                "bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c",
                "bitcoincash:qrehqueqhw629p6e57994436w730t4rzasnly00ht0" }, ResponseTimeOut);

            Assert.Equal(2, result.Length);

            Assert.Equal("bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c", result[0].CashAddress);
            Assert.Equal("1Fg4r9iDrEkCcDmHTy2T79EusNfhyQpu7W", result[0].LegacyAddress);
            Assert.Equal("bitcoincash:qrehqueqhw629p6e57994436w730t4rzasnly00ht0", result[1].CashAddress);
            Assert.Equal("1PCBukyYULnmraUpMy2hW1Y1ngEQTN8DtF", result[1].LegacyAddress);
        }

        [Fact]
        public void GetUTXOsShouldReturn()
        {
            // TODO: check inside utxos array too (need current data source to compare against)
            var result = Address.GetUTXOs("bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c", ResponseTimeOut);

            Assert.Equal("bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c", result.CashAddress);
            Assert.Equal("1Fg4r9iDrEkCcDmHTy2T79EusNfhyQpu7W", result.LegacyAddress);
            Assert.Equal("76a914a0f531f4ff810a415580c12e54a7072946bb927e88ac", result.ScriptPubKey);
        }

        [Fact]
        public void GetUTXOsMultiShouldReturn()
        {
            // TODO: check inside utxos array too (need current data source to compare against)
            var result = Address.GetUTXOs(new[] {
                "bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c",
                "bitcoincash:qrehqueqhw629p6e57994436w730t4rzasnly00ht0" }, ResponseTimeOut);

            Assert.Equal(2, result.Length);

            Assert.Equal("bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c", result[0].CashAddress);
            Assert.Equal("1Fg4r9iDrEkCcDmHTy2T79EusNfhyQpu7W", result[0].LegacyAddress);
            Assert.Equal("76a914a0f531f4ff810a415580c12e54a7072946bb927e88ac", result[0].ScriptPubKey);
            Assert.Equal("bitcoincash:qrehqueqhw629p6e57994436w730t4rzasnly00ht0", result[1].CashAddress);
            Assert.Equal("1PCBukyYULnmraUpMy2hW1Y1ngEQTN8DtF", result[1].LegacyAddress);
            Assert.Equal("76a914f3707320bbb4a28759a78a5ad63a77a2f5d462ec88ac", result[1].ScriptPubKey);
        }

        [Fact]
        public void GetUnconfirmedShouldReturn()
        {
            // TODO: check inside utxos array too (need current data source to compare against)
            var result = Address.GetUnconfirmedTransactions("bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c", ResponseTimeOut);

            Assert.Equal("bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c", result.CashAddress);
            Assert.Equal("1Fg4r9iDrEkCcDmHTy2T79EusNfhyQpu7W", result.LegacyAddress);
            Assert.Equal("76a914a0f531f4ff810a415580c12e54a7072946bb927e88ac", result.ScriptPubKey);
        }

        [Fact]
        public void GetUnconfirmedMultiShouldReturn()
        {
            // TODO: check inside utxos array too (need current data source to compare against)
            var result = Address.GetUnconfirmedTransactions(new[] {
                "bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c",
                "bitcoincash:qrehqueqhw629p6e57994436w730t4rzasnly00ht0" }, ResponseTimeOut);

            Assert.Equal(2, result.Length);

            Assert.Equal("bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c", result[0].CashAddress);
            Assert.Equal("1Fg4r9iDrEkCcDmHTy2T79EusNfhyQpu7W", result[0].LegacyAddress);
            Assert.Equal("76a914a0f531f4ff810a415580c12e54a7072946bb927e88ac", result[0].ScriptPubKey);
            Assert.Equal("bitcoincash:qrehqueqhw629p6e57994436w730t4rzasnly00ht0", result[1].CashAddress);
            Assert.Equal("1PCBukyYULnmraUpMy2hW1Y1ngEQTN8DtF", result[1].LegacyAddress);
            Assert.Equal("76a914f3707320bbb4a28759a78a5ad63a77a2f5d462ec88ac", result[1].ScriptPubKey);
        }

        [Fact]
        public void GetTransactionsShouldReturn()
        {
            // TODO: check inside txs array too (need current data source to compare against)
            var result = Address.GetTransactions("bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c", ResponseTimeOut);

            Assert.Equal("bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c", result.CashAddress);
            Assert.Equal("1Fg4r9iDrEkCcDmHTy2T79EusNfhyQpu7W", result.LegacyAddress);
            Assert.True(result.PagesTotal >= 4);
            Assert.Equal(0, result.CurrentPage);

            result = Address.GetTransactions("bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c", ResponseTimeOut, 1);

            Assert.Equal("bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c", result.CashAddress);
            Assert.Equal("1Fg4r9iDrEkCcDmHTy2T79EusNfhyQpu7W", result.LegacyAddress);
            Assert.True(result.PagesTotal >= 4);
            Assert.Equal(1, result.CurrentPage);
        }

        [Fact]
        public void GetTransactionsMultiShouldReturn()
        {
            // TODO: check inside txs array too (need current data source to compare against)
            var result = Address.GetTransactions(new[] {
                "bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c",
                "bitcoincash:qrehqueqhw629p6e57994436w730t4rzasnly00ht0" }, ResponseTimeOut);

            Assert.Equal(2, result.Length);

            Assert.Equal("bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c", result[0].CashAddress);
            Assert.Equal("1Fg4r9iDrEkCcDmHTy2T79EusNfhyQpu7W", result[0].LegacyAddress);
            Assert.True(result[0].PagesTotal >= 4);
            Assert.Equal(0, result[0].CurrentPage);
            Assert.Equal("bitcoincash:qrehqueqhw629p6e57994436w730t4rzasnly00ht0", result[1].CashAddress);
            Assert.Equal("1PCBukyYULnmraUpMy2hW1Y1ngEQTN8DtF", result[1].LegacyAddress);
            Assert.True(result[1].PagesTotal >= 2);
            Assert.Equal(0, result[1].CurrentPage);
        }
    }
}

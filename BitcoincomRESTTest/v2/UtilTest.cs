using System.Linq;
using BitcoincomREST.v2;
using Xunit;

namespace BitcoincomRESTTest.v2
{
    public class UtilTest
    {
        private const int ResponseTimeOut = 30000;

        [Fact]
        public void ValidateAddressShouldReturn()
        {
            var result = Util.ValidateAddress("bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c", ResponseTimeOut);

            Assert.True(result.IsValid);
            Assert.Equal("bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c", result.Address);
            Assert.Equal("76a914a0f531f4ff810a415580c12e54a7072946bb927e88ac", result.ScriptPubKey);
            Assert.False(result.IsMine);
            Assert.False(result.IsWatchOnly);
            Assert.False(result.IsScript);

            result = Util.ValidateAddress("bitcoincash:qrehqueqhw629p6e57994436w730t4rzasnly00ht0", ResponseTimeOut);

            Assert.True(result.IsValid);
            Assert.Equal("bitcoincash:qrehqueqhw629p6e57994436w730t4rzasnly00ht0", result.Address);
            Assert.Equal("76a914f3707320bbb4a28759a78a5ad63a77a2f5d462ec88ac", result.ScriptPubKey);
            Assert.False(result.IsMine);
            Assert.False(result.IsWatchOnly);
            Assert.False(result.IsScript);

            result = Util.ValidateAddress("bitcoincash:qzs02v05l7qs4s24srqju498qu55dwuj0cx5ehjm2c", ResponseTimeOut);
            Assert.False(result.IsValid);
        }

        [Fact (Skip = "Bulk Address Validation is Broken! Returns the same result multiple times!")]
        public void ValidateAddressesMultiShouldReturn()
        {
            var result = Util.ValidateAddresses( new [] {"bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c",
                "bitcoincash:qrehqueqhw629p6e57994436w730t4rzasnly00ht0" }, ResponseTimeOut);

            Assert.Equal(2, result.Length);

            Assert.Contains(result, x => x.Address == "bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c");

            var result1 =
                result.First(x => x.Address == "bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c");

            Assert.True(result1.IsValid);
            Assert.Equal("bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c", result1.Address);
            Assert.Equal("76a914a0f531f4ff810a415580c12e54a7072946bb927e88ac", result1.ScriptPubKey);
            Assert.False(result1.IsMine);
            Assert.False(result1.IsWatchOnly);
            Assert.False(result1.IsScript);

            
            Assert.Contains(result, x => x.Address == "bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c");

            var result2 =
                result.First(x => x.Address == "bitcoincash:qzs02v05l7qs5s24srqju498qu55dwuj0cx5ehjm2c");

            Assert.True(result2.IsValid);
            Assert.Equal("bitcoincash:qrehqueqhw629p6e57994436w730t4rzasnly00ht0", result2.Address);
            Assert.Equal("76a914f3707320bbb4a28759a78a5ad63a77a2f5d462ec88ac", result2.ScriptPubKey);
            Assert.False(result2.IsMine);
            Assert.False(result2.IsWatchOnly);
            Assert.False(result2.IsScript);


            result1 = Util.ValidateAddress("bitcoincash:qzs02v05l7qs4s24srqju498qu55dwuj0cx5ehjm2c", ResponseTimeOut);
            Assert.False(result1.IsValid);
        }
    }
}
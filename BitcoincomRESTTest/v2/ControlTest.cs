using BitcoincomREST.v2;
using Xunit;

namespace BitcoincomRESTTest.v2
{
    public class ControlTest
    {
        private const int ResponseTimeOut = 30000;

        [Fact]
        public void GetInfoShouldReturn()
        {
            var result = Control.GetInfo(ResponseTimeOut);

            Assert.True(result.Connections > 8);
            Assert.True(result.Blocks > 579990);
            Assert.Equal("", result.Proxy);
            Assert.Equal(0, result.PayTxFee);
            Assert.Equal(0.00001, result.RelayFee);
            Assert.False(result.TestNet);
            Assert.True(result.Difficulty > 3000000000);
        }
    }
}
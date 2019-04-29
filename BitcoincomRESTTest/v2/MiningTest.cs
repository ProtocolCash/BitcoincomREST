using BitcoincomREST.v2;
using Xunit;

namespace BitcoincomRESTTest.v2
{
    public class MiningTest
    {
        private const int ResponseTimeOut = 30000;

        [Fact]
        public void GetMiningInfoShouldReturn()
        {
            var result = Mining.GetMiningInfo(ResponseTimeOut);

            Assert.True(result.Blocks > 579991);
            Assert.True(result.Difficulty > 3000000000);
            Assert.True(result.NetworkHashPs > 300000000000000000);
            Assert.Equal("main", result.Chain);
        }

        [Fact]
        public void GetNetworkHashPsShouldReturn()
        {
            var result = Mining.GetNetworkHashPerSecond(ResponseTimeOut, 120, 500000);

            Assert.Equal(525612384729990500UL, result);

            result = Mining.GetNetworkHashPerSecond(ResponseTimeOut, 120, 500010);

            Assert.Equal(509679507717161100UL, result);
        }
    }
}
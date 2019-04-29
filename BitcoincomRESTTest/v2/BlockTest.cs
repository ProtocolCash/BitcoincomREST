using System.Linq;
using BitcoincomREST.v2;
using Xunit;

namespace BitcoincomRESTTest.v2
{
    public class BlockTest
    {
        private const int ResponseTimeOut = 30000;

        [Fact]
        public void GetDetailsByHashShouldReturn()
        {
            var result = Block.GetDetailsByHash("000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201",
                ResponseTimeOut);

            Assert.Equal("000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201", result.Hash);
            Assert.Equal(81577, result.Size);
            Assert.Equal(500000, result.Height);
            Assert.Equal(536870912, result.Version);
            Assert.Equal("5ebaa53d24c8246c439ccd9f142cbe93fc59582e7013733954120e9baab201df", result.Tx[0]);
            Assert.Equal("7157188ba241424c25585c53dd791308e00d06832edc85758905629973790e88", result.Tx[5]);
            Assert.Equal(1509343584, result.Time);
            Assert.Equal(3604508752, result.Nonce);
            Assert.Equal("1809b91a", result.Bits);
            Assert.Equal(113081236211.45331, result.Difficulty);
            Assert.Equal("0000000000000000043831d6ebb013716f0580287ee5e5687e27d0ed72e6e523", result.PreviousBlockHash);
            Assert.Equal("00000000000000000568f0a96bf4348847bc84e455cbfec389f27311037a20f3", result.NextBlockHash);
            Assert.Equal(12.5, result.Reward);
            Assert.True(result.IsMainChain);
            Assert.Equal("ViaBTC", result.PoolInfo.PoolName);
            Assert.Equal("https://viabtc.com/", result.PoolInfo.URL);
        }

        [Fact]
        public void GetDetailsByMultiHashShouldReturn()
        {
            var result = Block.GetDetailsByHash(new[]
            {
                "000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201",
                "000000000000000000aa5f1eee4ba66a5d71b3512788ea1ddd161441846d7900"
            }, ResponseTimeOut);

            Assert.Equal(2, result.Length);

            Assert.Contains(result, x => x.Hash == "000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201");
            var result1 = result[0];

            Assert.Equal("000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201", result1.Hash);
            Assert.Equal(81577, result1.Size);
            Assert.Equal(500000, result1.Height);
            Assert.Equal(536870912, result1.Version);
            Assert.Equal("5ebaa53d24c8246c439ccd9f142cbe93fc59582e7013733954120e9baab201df", result1.Tx[0]);
            Assert.Equal("7157188ba241424c25585c53dd791308e00d06832edc85758905629973790e88", result1.Tx[5]);
            Assert.Equal(1509343584, result1.Time);
            Assert.Equal(3604508752, result1.Nonce);
            Assert.Equal("1809b91a", result1.Bits);
            Assert.Equal(113081236211.45331, result1.Difficulty);
            Assert.Equal("0000000000000000043831d6ebb013716f0580287ee5e5687e27d0ed72e6e523", result1.PreviousBlockHash);
            Assert.Equal("00000000000000000568f0a96bf4348847bc84e455cbfec389f27311037a20f3", result1.NextBlockHash);
            Assert.Equal(12.5, result1.Reward);
            Assert.True(result1.IsMainChain);
            Assert.Equal("ViaBTC", result1.PoolInfo.PoolName);
            Assert.Equal("https://viabtc.com/", result1.PoolInfo.URL);

            Assert.Contains(result, x => x.Hash == "000000000000000000aa5f1eee4ba66a5d71b3512788ea1ddd161441846d7900");
            var result2 = result[1];

            Assert.Equal("000000000000000000aa5f1eee4ba66a5d71b3512788ea1ddd161441846d7900", result2.Hash);
            Assert.Equal(163173, result2.Size);
            Assert.Equal(579924, result2.Height);
            Assert.Equal(549453824, result2.Version);
            Assert.Equal("cb4c369f728b1163383341b7cb6aab3b0195397eb09f608ba54fcbd1ae3a379e", result2.Tx[0]);
            Assert.Equal("01fe118bc39fe6bf40e490e7d7fdd1bcf08b2b5ecf53312ca5fb1857855e0634", result2.Tx[5]);
            Assert.Equal(1556269379, result2.Time);
            Assert.Equal(436081160, result2.Nonce);
            Assert.Equal("1803976c", result2.Bits);
            Assert.Equal(306138769803.9706, result2.Difficulty);
            Assert.Equal("000000000000000000000000000000000000000000e7eb777c8aac335d422ca3", result2.ChainWork);
            Assert.Equal("00000000000000000035aeb320dc0d36b777cc8cc7651faebb2df491f49a4c84", result2.PreviousBlockHash);
            Assert.Equal("0000000000000000016245c9cd95f3b4396d82dd57edc9c53053322b22a9e721", result2.NextBlockHash);
            Assert.Equal(12.5, result2.Reward);
            Assert.True(result2.IsMainChain);
            Assert.Equal("ViaBTC", result2.PoolInfo.PoolName);
            Assert.Equal("https://viabtc.com/", result2.PoolInfo.URL);
        }


        [Fact]
        public void GetDetailsByHeightShouldReturn()
        {
            var result = Block.GetDetailsByHeight(500000, ResponseTimeOut);

            Assert.Equal("000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201", result.Hash);
            Assert.Equal(81577, result.Size);
            Assert.Equal(500000, result.Height);
            Assert.Equal(536870912, result.Version);
            Assert.Equal("5ebaa53d24c8246c439ccd9f142cbe93fc59582e7013733954120e9baab201df", result.Tx[0]);
            Assert.Equal("7157188ba241424c25585c53dd791308e00d06832edc85758905629973790e88", result.Tx[5]);
            Assert.Equal(1509343584, result.Time);
            Assert.Equal(3604508752, result.Nonce);
            Assert.Equal("1809b91a", result.Bits);
            Assert.Equal(113081236211.45331, result.Difficulty);
            Assert.Equal("0000000000000000043831d6ebb013716f0580287ee5e5687e27d0ed72e6e523", result.PreviousBlockHash);
            Assert.Equal("00000000000000000568f0a96bf4348847bc84e455cbfec389f27311037a20f3", result.NextBlockHash);
            Assert.Equal(12.5, result.Reward);
            Assert.True(result.IsMainChain);
            Assert.Equal("ViaBTC", result.PoolInfo.PoolName);
            Assert.Equal("https://viabtc.com/", result.PoolInfo.URL);
        }

        [Fact (Skip = "Multiple Details at Height is Broken! Returns the same result multiple times!")]
        public void GetDetailsByMultiHeightShouldReturn()
        {
            var result = Block.GetDetailsByHeight(new[] { 500000, 579924 }, ResponseTimeOut);

            Assert.Equal(2, result.Length);

            Assert.Contains(result, x => x.Height == 500000);
            
            var result1 = result.First(x => x.Height == 500000);

            Assert.Equal("000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201", result1.Hash);
            Assert.Equal(81577, result1.Size);
            Assert.Equal(500000, result1.Height);
            Assert.Equal(536870912, result1.Version);
            Assert.Equal("5ebaa53d24c8246c439ccd9f142cbe93fc59582e7013733954120e9baab201df", result1.Tx[0]);
            Assert.Equal("7157188ba241424c25585c53dd791308e00d06832edc85758905629973790e88", result1.Tx[5]);
            Assert.Equal(1509343584, result1.Time);
            Assert.Equal(3604508752, result1.Nonce);
            Assert.Equal("1809b91a", result1.Bits);
            Assert.Equal(113081236211.45331, result1.Difficulty);
            Assert.Equal("0000000000000000043831d6ebb013716f0580287ee5e5687e27d0ed72e6e523", result1.PreviousBlockHash);
            Assert.Equal("00000000000000000568f0a96bf4348847bc84e455cbfec389f27311037a20f3", result1.NextBlockHash);
            Assert.Equal(12.5, result1.Reward);
            Assert.True(result1.IsMainChain);
            Assert.Equal("ViaBTC", result1.PoolInfo.PoolName);
            Assert.Equal("https://viabtc.com/", result1.PoolInfo.URL);

            Assert.Contains(result, x => x.Height == 579924);

            var result2 = result.First(x => x.Height == 579924);

            Assert.Equal("000000000000000000aa5f1eee4ba66a5d71b3512788ea1ddd161441846d7900", result2.Hash);
            Assert.Equal(163173, result2.Size);
            Assert.Equal(579924, result2.Height);
            Assert.Equal(549453824, result2.Version);
            Assert.Equal("cb4c369f728b1163383341b7cb6aab3b0195397eb09f608ba54fcbd1ae3a379e", result2.Tx[0]);
            Assert.Equal("01fe118bc39fe6bf40e490e7d7fdd1bcf08b2b5ecf53312ca5fb1857855e0634", result2.Tx[5]);
            Assert.Equal(1556269379, result2.Time);
            Assert.Equal(436081160, result2.Nonce);
            Assert.Equal("1803976c", result2.Bits);
            Assert.Equal(306138769803.9706, result2.Difficulty);
            Assert.Equal("000000000000000000000000000000000000000000e7eb777c8aac335d422ca3", result2.ChainWork);
            Assert.Equal("00000000000000000035aeb320dc0d36b777cc8cc7651faebb2df491f49a4c84", result2.PreviousBlockHash);
            Assert.Equal("0000000000000000016245c9cd95f3b4396d82dd57edc9c53053322b22a9e721", result2.NextBlockHash);
            Assert.Equal(12.5, result2.Reward);
            Assert.True(result2.IsMainChain);
            Assert.Equal("ViaBTC", result2.PoolInfo.PoolName);
            Assert.Equal("https://viabtc.com/", result2.PoolInfo.URL);
        }
    }
}

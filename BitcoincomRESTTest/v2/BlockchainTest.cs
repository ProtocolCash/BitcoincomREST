using System;
using System.Linq;
using BitcoincomREST.v2;
using BitcoincomREST.v2.Model;
using Xunit;

namespace BitcoincomRESTTest.v2
{
    public class BlockchainTest
    {
        private const int ResponseTimeOut = 30000;

        [Fact]
        public void GetAllMempoolEntriesShouldReturn()
        {
            var result = Blockchain.GetAllMempoolEntries(ResponseTimeOut);

            foreach (var (id, info) in result)
            {
                // the absolute minimum transaction size possible
                Assert.True(info.Size >= 60);
                // basic validation on height
                Assert.True(info.Height > 570000);
                // transaction hash must be 64 hex characters
                Assert.Equal(64, id.Length);
            }
        }

        [Fact]
        public void GetAllMempoolEntryIdsShouldReturn()
        {
            var result = Blockchain.GetAllMempoolEntryIds(ResponseTimeOut);

            foreach (var id in result)
            {
                // transaction hash must be 64 hex characters
                Assert.Equal(64, id.Length);
            }
        }

        [Fact]
        public void GetBestBlockHashShouldReturn()
        {
            var result = Blockchain.GetBestBlockHash(ResponseTimeOut);

            Assert.StartsWith("00000000000000", result);
            Assert.Equal(64, result.Length);
        }

        [Fact]
        public void GetBlockChainInfoShouldReturn()
        {
            var result = Blockchain.GetBlockChainInfo(ResponseTimeOut);

            Assert.Equal("main", result.Chain);
            Assert.True(result.Blocks > 579981);
            Assert.True(result.Headers > 579981);
            Assert.True(result.MedianTime > 1556300582);
            Assert.False(result.Pruned);
            Assert.Contains(result.SoftForks, x => x.Id == "bip34");
            var fork = result.SoftForks.First(x => x.Id == "bip34");
            Assert.True(fork.Version == 2);
            Assert.True(fork.Reject.Status);
        }

        [Fact]
        public void GetBlockCountShouldReturn()
        {
            var result = Blockchain.GetBlockCount(ResponseTimeOut);

            Assert.True(result > 579981);
        }

        [Fact]
        public void GetBlockHeaderShouldReturn()
        {
            var result = Blockchain.GetBlockHeader("000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201",
                ResponseTimeOut);

            Assert.Equal("000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201", result.Hash);
            Assert.True(result.Confirmations > 79980);
            Assert.Equal(500000, result.Height);
            Assert.Equal(536870912, result.Version);
            Assert.Equal("20000000", result.VersionHex);
            Assert.Equal("4af279645e1b337e655ae3286fc2ca09f58eb01efa6ab27adedd1e9e6ec19091", result.MerkleRoot);
            Assert.Equal(1509343584, result.Time);
            Assert.Equal(1509336533, result.MedianTime);
            Assert.Equal(3604508752, result.Nonce);
            Assert.Equal("1809b91a", result.Bits);
            Assert.Equal(113081236211.4533, result.Difficulty);
            Assert.Equal("0000000000000000000000000000000000000000007ae48aca46e3b449ad9714", result.ChainWork);
            Assert.Equal("0000000000000000043831d6ebb013716f0580287ee5e5687e27d0ed72e6e523", result.PreviousBlockHash);
            Assert.Equal("00000000000000000568f0a96bf4348847bc84e455cbfec389f27311037a20f3", result.NextBlockHash);
        }

        [Fact(Skip = "Multiple Block Headers by Hash is Broken! Returns the same result multiple times!")]
        public void GetMultiBlockHeaderShouldReturn()
        {
            var result = Blockchain.GetBlockHeader(
                new[]
                {
                    "000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201",
                    "00000000000000000568f0a96bf4348847bc84e455cbfec389f27311037a20f3"
                }, ResponseTimeOut);

            Assert.Equal(2, result.Length);

            Assert.Contains(result, x => x.Hash == "000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201");

            var result1 =
                result.First(x => x.Hash == "000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201");

            Assert.Equal("000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201", result1.Hash);
            Assert.True(result1.Confirmations > 79980);
            Assert.Equal(500001, result1.Height);
            Assert.Equal(536870912, result1.Version);
            Assert.Equal("20000000", result1.VersionHex);
            Assert.Equal("01fcc7f4b25840459352005c77e7917bab20bddf1b398f4392e3a299851aa696", result1.MerkleRoot);
            Assert.Equal(1509345037, result1.Time);
            Assert.Equal(1509336585, result1.MedianTime);
            Assert.Equal(2406916250, result1.Nonce);
            Assert.Equal("1809b91a", result1.Bits);
            Assert.Equal(113081236211.4533, result1.Difficulty);
            Assert.Equal("0000000000000000000000000000000000000000007ae4a51e8bf2ecccf1d9a1", result1.ChainWork);
            Assert.Equal("000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201", result1.PreviousBlockHash);
            Assert.Equal("00000000000000000797607b2b69d1561027dbaf28545a33d6ec3adb89f8e564", result1.NextBlockHash);

            Assert.Contains(result, x => x.Hash == "00000000000000000568f0a96bf4348847bc84e455cbfec389f27311037a20f3");

            var result2 =
                result.First(x => x.Hash == "00000000000000000568f0a96bf4348847bc84e455cbfec389f27311037a20f3");

            Assert.Equal("00000000000000000568f0a96bf4348847bc84e455cbfec389f27311037a20f3", result2.Hash);
            Assert.True(result2.Confirmations > 79980);
            Assert.Equal(500001, result2.Height);
            Assert.Equal(536870912, result2.Version);
            Assert.Equal("20000000", result2.VersionHex);
            Assert.Equal("01fcc7f4b25840459352005c77e7917bab20bddf1b398f4392e3a299851aa696", result2.MerkleRoot);
            Assert.Equal(1509345037, result2.Time);
            Assert.Equal(1509336585, result2.MedianTime);
            Assert.Equal(2406916250, result2.Nonce);
            Assert.Equal("1809b91a", result2.Bits);
            Assert.Equal(113081236211.4533, result2.Difficulty);
            Assert.Equal("0000000000000000000000000000000000000000007ae4a51e8bf2ecccf1d9a1", result2.ChainWork);
            Assert.Equal("000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201", result2.PreviousBlockHash);
            Assert.Equal("00000000000000000797607b2b69d1561027dbaf28545a33d6ec3adb89f8e564", result2.NextBlockHash);
        }

        [Fact]
        public void GetChainTipsShouldReturn()
        {
            var result = Blockchain.GetChainTips(ResponseTimeOut);

            Assert.All(result, x => Assert.True(Enum.IsDefined(typeof(ChainTipStatus), x.Status)));

            Assert.Contains(result, x => x.Status == ChainTipStatus.Active);

            var active = result.First(x => x.Status == ChainTipStatus.Active);

            Assert.Equal(0, active.BranchLength);
            Assert.True(active.Height > 579981);
        }

        [Fact]
        public void GetDifficultyShouldReturn()
        {
            var result = Blockchain.GetDifficulty(ResponseTimeOut);

            // 10% of actual network difficulty at time test was written - unlikely it will ever fall below this
            Assert.True(result > 3000000000);
            // There should be a decimal - a difficulty ending in .000 has 1/1000 odds of occuring
            // (might eventually, but will be obvious why this Assert fails then)
            Assert.NotEqual(0, result % 1);
        }

        [Fact]
        public void GetMempoolEntryShouldReturn()
        {
            Assert.Throws<AggregateException>(() =>
            {
                Blockchain.GetMempoolEntry("fe28050b93faea61fa88c4c630f0e1f0a1c24d0082dd0e10d369e13212128f33",
                    ResponseTimeOut);
            });

            // get current mempool entries
            var entries = Blockchain.GetAllMempoolEntryIds(ResponseTimeOut);

            if (entries.Length == 0)
                return;

            var result = Blockchain.GetMempoolEntry(entries[0], ResponseTimeOut);

            Assert.True(result.Height > 579981);
            Assert.True(result.Size > 60);
        }

        [Fact(Skip = "Multiple Mempool Entries by txid is Broken! Returns the same result multiple times!")]
        public void GetMempoolEntryMultiShouldReturn()
        {
            Assert.Throws<AggregateException>(() =>
            {
                Blockchain.GetMempoolEntry(
                    new[]
                    {
                        "fe28050b93faea61fa88c4c630f0e1f0a1c24d0082dd0e10d369e13212128f33",
                        "00000000000000000568f0a96bf4348847bc84e455cbfec389f27311037a20f3"
                    }, ResponseTimeOut);
            });

            // get current mempool entries
            var entries = Blockchain.GetAllMempoolEntryIds(ResponseTimeOut);

            Assert.True(entries.Length > 1, "Try Again! Not enough transactions in memory pool to attempt test.");

            var result = Blockchain.GetMempoolEntry(new[] {entries[0], entries[1], entries[2]}, ResponseTimeOut);

            Assert.Equal(3, result.Length);

            Assert.True(result[0].Size != result[1].Size);
            Assert.True(result[1].Size != result[2].Size);
            Assert.True(result[0].Size != result[2].Size);
            Assert.True(Math.Abs(result[0].Fee - result[1].Fee) > 0.00000001);
            Assert.True(Math.Abs(result[1].Fee - result[2].Fee) > 0.00000001);
            Assert.True(Math.Abs(result[0].Fee - result[2].Fee) > 0.00000001);
        }

        [Fact]
        public void GetMempoolInfoShouldReturn()
        {
            var result = Blockchain.GetMempoolInfo(ResponseTimeOut);

            Assert.True(result.Size > 0);
            Assert.True(result.Bytes > result.Size);
            Assert.True(result.Usage > result.Bytes);
            Assert.Equal(300000000, result.MaxMempool);
            Assert.Equal(0, result.MempoolMinFee);
        }

        [Fact]
        public void GetRawBlockHeaderShouldReturn()
        {
            var result =
                Blockchain.GetRawBlockHeader("000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201",
                    ResponseTimeOut);

            Assert.Equal(
                "0000002023e5e672edd0277e68e5e57e2880056f7113b0ebd631380400000000000000009190c16e9e1eddde7ab26afa1eb08ef509cac26f28e35a657e331b5e6479f24a60c1f6591ab909185070d8d6",
                result);

            result = Blockchain.GetRawBlockHeader("00000000000000000568f0a96bf4348847bc84e455cbfec389f27311037a20f3",
                ResponseTimeOut);

            Assert.Equal(
                "0000002001b2328355f4a4dc9efa5c610687304507b7df9f3f4de105000000000000000096a61a8599a2e392438f391bdfbd20ab7b91e7775c005293454058b2f4c7fc010dc7f6591ab909189aa0768f",
                result);
        }

        [Fact(Skip = "Multiple Raw Block Headers by Hash is Broken! Returns the same result multiple times!")]
        public void GetRawBlockHeaderMultiShouldReturn()
        {
            var result = Blockchain.GetRawBlockHeader(new[]
            {
                "000000000000000005e14d3f9fdfb70745308706615cfa9edca4f4558332b201",
                "00000000000000000568f0a96bf4348847bc84e455cbfec389f27311037a20f3"
            }, ResponseTimeOut);

            Assert.Equal(2, result.Length);

            Assert.Contains(result,
                x =>
                    x ==
                    "0000002023e5e672edd0277e68e5e57e2880056f7113b0ebd631380400000000000000009190c16e9e1eddde7ab26afa1eb08ef509cac26f28e35a657e331b5e6479f24a60c1f6591ab909185070d8d6");
            Assert.Contains(result,
                x =>
                    x ==
                    "0000002001b2328355f4a4dc9efa5c610687304507b7df9f3f4de105000000000000000096a61a8599a2e392438f391bdfbd20ab7b91e7775c005293454058b2f4c7fc010dc7f6591ab909189aa0768f");
        }

        [Fact]
        public void GetTxOutShouldReturn()
        {
            var result = Blockchain.GetTxOut("fe28050b93faea61fa88c4c630f0e1f0a1c24d0082dd0e10d369e13212128f33", 0,
                ResponseTimeOut, false);

            Assert.True(result.Confirmations > 578986);
            Assert.Equal(50, result.Value);
            Assert.Equal(
                "04f5eeb2b10c944c6b9fbcfff94c35bdeecd93df977882babc7f3a2cf7f5c81d3b09a68db7f0e04f21de5d4230e75e6dbe7ad16eefe0d4325a62067dc6f369446a OP_CHECKSIG",
                result.ScriptPubKey.ScriptAsm);
            Assert.Equal(
                "4104f5eeb2b10c944c6b9fbcfff94c35bdeecd93df977882babc7f3a2cf7f5c81d3b09a68db7f0e04f21de5d4230e75e6dbe7ad16eefe0d4325a62067dc6f369446aac",
                result.ScriptPubKey.Hex);
            Assert.Equal(1, result.ScriptPubKey.RegSigs);
            Assert.Equal("pubkey", result.ScriptPubKey.Type);
            Assert.Single(result.ScriptPubKey.Addresses);
            Assert.Equal("bitcoincash:qpej6mkrwca4tvy2snq4crhrf88v4ljspysx0ueetk", result.ScriptPubKey.Addresses[0]);
        }

        [Fact]
        public void GetTxOutProofShouldReturn()
        {
            var result = Blockchain.GetTxOutProof("5165dc531aad05d1149bb0f0d9b7bda99c73e2f05e314bcfb5b4bb9ca5e1af5e",
                ResponseTimeOut);

            Assert.Equal("000000202cbe31a32f4ad5b42877a9ccf9ff6edb3f5ab29ff73ec9000000000000000000069061a8809fed6557fa87eeb5aa7ac9e6720dcb2e2f401b40b7d83be5b4cb4f20a1e95b8c8d01188ca7c098e20100000a3705adb29177f22766afb07d46eb1d3f16a68fdd01c1ede671fcb954899ffed4c161c0a33aa8f6e562e40b1e0124818663e063004720d8d7e9074808a1f16ca56ba218571cb8069bc45bc8c6496ad9611b35d412e2545211ba85438be487d6dc39cd0ae63a41be9a89c4ed823fa6eceb0ceffe13638defa01109a514e639b89e5eafe1a59cbbb4b5cf4b315ef0e2739ca9bdb7d9f0b09b14d105ad1a53dc655176895cacc3f897d5088b004113f886df266edd1ff797f4550885f32380c8fb575be00072239baa70ccf354882e8c50a1d01e81ab2c85146d9e8c3c75140eca2d9d5640af739a86047493e24b1393745914a75fdfe19f081626a5846353c67b45ccf2dd6a753ba118e89239b7916be2ee06e34dc85257228edeaaca06efa0a565580872eff1787360bdf7ff274bb49437bef6a368ab578e34b739ddcc16088a8603ad3700", result);

            result = Blockchain.GetTxOutProof("5165dc531aad05d1149bb0f0d9b7bda99c73e2f05e314bcfb5b4bb9ca5e1af5e",
                ResponseTimeOut);

            Assert.Equal("000000202cbe31a32f4ad5b42877a9ccf9ff6edb3f5ab29ff73ec9000000000000000000069061a8809fed6557fa87eeb5aa7ac9e6720dcb2e2f401b40b7d83be5b4cb4f20a1e95b8c8d01188ca7c098e20100000a3705adb29177f22766afb07d46eb1d3f16a68fdd01c1ede671fcb954899ffed4c161c0a33aa8f6e562e40b1e0124818663e063004720d8d7e9074808a1f16ca56ba218571cb8069bc45bc8c6496ad9611b35d412e2545211ba85438be487d6dc39cd0ae63a41be9a89c4ed823fa6eceb0ceffe13638defa01109a514e639b89e5eafe1a59cbbb4b5cf4b315ef0e2739ca9bdb7d9f0b09b14d105ad1a53dc655176895cacc3f897d5088b004113f886df266edd1ff797f4550885f32380c8fb575be00072239baa70ccf354882e8c50a1d01e81ab2c85146d9e8c3c75140eca2d9d5640af739a86047493e24b1393745914a75fdfe19f081626a5846353c67b45ccf2dd6a753ba118e89239b7916be2ee06e34dc85257228edeaaca06efa0a565580872eff1787360bdf7ff274bb49437bef6a368ab578e34b739ddcc16088a8603ad3700", result);


        }

        [Fact (Skip = "Multiple TxOut Proof is Broken! Returns the same result multiple times!")]
        public void GetTxOutProofMultiShouldReturn()
        {
            var result = Blockchain.GetTxOutProof(new[] { "a5f972572ee1753e2fd2457dd61ce5f40fa2f8a30173d417e49feef7542c96a1", "5165dc531aad05d1149bb0f0d9b7bda99c73e2f05e314bcfb5b4bb9ca5e1af5e" },
                ResponseTimeOut);

            Assert.Equal(2, result.Length);

            Assert.Contains(result, x =>
                x ==
                "000000202cbe31a32f4ad5b42877a9ccf9ff6edb3f5ab29ff73ec9000000000000000000069061a8809fed6557fa87eeb5aa7ac9e6720dcb2e2f401b40b7d83be5b4cb4f20a1e95b8c8d01188ca7c098e20100000a3705adb29177f22766afb07d46eb1d3f16a68fdd01c1ede671fcb954899ffed4c161c0a33aa8f6e562e40b1e0124818663e063004720d8d7e9074808a1f16ca56ba218571cb8069bc45bc8c6496ad9611b35d412e2545211ba85438be487d6dc39cd0ae63a41be9a89c4ed823fa6eceb0ceffe13638defa01109a514e639b89e5eafe1a59cbbb4b5cf4b315ef0e2739ca9bdb7d9f0b09b14d105ad1a53dc655176895cacc3f897d5088b004113f886df266edd1ff797f4550885f32380c8fb575be00072239baa70ccf354882e8c50a1d01e81ab2c85146d9e8c3c75140eca2d9d5640af739a86047493e24b1393745914a75fdfe19f081626a5846353c67b45ccf2dd6a753ba118e89239b7916be2ee06e34dc85257228edeaaca06efa0a565580872eff1787360bdf7ff274bb49437bef6a368ab578e34b739ddcc16088a8603ad3700");

            Assert.Contains(result, x =>
                x ==
                "0000002001b2328355f4a4dc9efa5c610687304507b7df9f3f4de105000000000000000096a61a8599a2e392438f391bdfbd20ab7b91e7775c005293454058b2f4c7fc010dc7f6591ab909189aa0768f");
        }

        [Fact]
        public void VerifyTxOutProofShouldReturn()
        {
            var result = Blockchain.VerifyTxOutProof("000000202cbe31a32f4ad5b42877a9ccf9ff6edb3f5ab29ff73ec9000000000000000000069061a8809fed6557fa87eeb5aa7ac9e6720dcb2e2f401b40b7d83be5b4cb4f20a1e95b8c8d01188ca7c098e20100000a3705adb29177f22766afb07d46eb1d3f16a68fdd01c1ede671fcb954899ffed4c161c0a33aa8f6e562e40b1e0124818663e063004720d8d7e9074808a1f16ca56ba218571cb8069bc45bc8c6496ad9611b35d412e2545211ba85438be487d6dc39cd0ae63a41be9a89c4ed823fa6eceb0ceffe13638defa01109a514e639b89e5eafe1a59cbbb4b5cf4b315ef0e2739ca9bdb7d9f0b09b14d105ad1a53dc655176895cacc3f897d5088b004113f886df266edd1ff797f4550885f32380c8fb575be00072239baa70ccf354882e8c50a1d01e81ab2c85146d9e8c3c75140eca2d9d5640af739a86047493e24b1393745914a75fdfe19f081626a5846353c67b45ccf2dd6a753ba118e89239b7916be2ee06e34dc85257228edeaaca06efa0a565580872eff1787360bdf7ff274bb49437bef6a368ab578e34b739ddcc16088a8603ad3700", ResponseTimeOut);

            Assert.Contains(result, x => x == "5165dc531aad05d1149bb0f0d9b7bda99c73e2f05e314bcfb5b4bb9ca5e1af5e");

            result = Blockchain.VerifyTxOutProof("0000c02078af6bf4b1b989eb3266ae528f601cb3936ee08e2e5518010000000000000000c0caf2d5fc5d78c9ac04fa2dafdc3ea7bf4ebe77d52ae6fa20f87093bc2effa7e0a1f45b95d0011874d7dac22b000000060d97bf42acbb71f01e6c3533e73a65f3116d7324a1e2abcf8b13f7aee92fe6eca1962c54f7ee9fe417d47301a3f8a20ff4e51cd67d45d22f3e75e12e5772f9a524d3b28b22a7e0b1c41f93fd7457a6951b0e20388288ea51278b2a345dcbecabff6ce741b6fc67fc4b55cef5f9e649bfac15b2238434129c50b335276a4eee4352713e3801135f1542eba103a13b40ec0d1b3f94f301ab113cfa397532351271fd97bb7dc08e3a8aa09e9396e266ec632252f0f510c1658e1347e1c4b474a8ce02fd00", ResponseTimeOut);

            Assert.Contains(result, x => x == "a5f972572ee1753e2fd2457dd61ce5f40fa2f8a30173d417e49feef7542c96a1");
        }

        [Fact(Skip = "Multiple Verify TxOut Proof is Broken! Returns the same result multiple times!")]
        public void VerifyTxOutProofMultiShouldReturn()
        {
            var result = Blockchain.VerifyTxOutProof(new[] { "000000202cbe31a32f4ad5b42877a9ccf9ff6edb3f5ab29ff73ec9000000000000000000069061a8809fed6557fa87eeb5aa7ac9e6720dcb2e2f401b40b7d83be5b4cb4f20a1e95b8c8d01188ca7c098e20100000a3705adb29177f22766afb07d46eb1d3f16a68fdd01c1ede671fcb954899ffed4c161c0a33aa8f6e562e40b1e0124818663e063004720d8d7e9074808a1f16ca56ba218571cb8069bc45bc8c6496ad9611b35d412e2545211ba85438be487d6dc39cd0ae63a41be9a89c4ed823fa6eceb0ceffe13638defa01109a514e639b89e5eafe1a59cbbb4b5cf4b315ef0e2739ca9bdb7d9f0b09b14d105ad1a53dc655176895cacc3f897d5088b004113f886df266edd1ff797f4550885f32380c8fb575be00072239baa70ccf354882e8c50a1d01e81ab2c85146d9e8c3c75140eca2d9d5640af739a86047493e24b1393745914a75fdfe19f081626a5846353c67b45ccf2dd6a753ba118e89239b7916be2ee06e34dc85257228edeaaca06efa0a565580872eff1787360bdf7ff274bb49437bef6a368ab578e34b739ddcc16088a8603ad3700",
                    "000000202cbe31a32f4ad5b42877a9ccf9ff6edb3f5ab29ff73ec9000000000000000000069061a8809fed6557fa87eeb5aa7ac9e6720dcb2e2f401b40b7d83be5b4cb4f20a1e95b8c8d01188ca7c098e20100000a3705adb29177f22766afb07d46eb1d3f16a68fdd01c1ede671fcb954899ffed4c161c0a33aa8f6e562e40b1e0124818663e063004720d8d7e9074808a1f16ca56ba218571cb8069bc45bc8c6496ad9611b35d412e2545211ba85438be487d6dc39cd0ae63a41be9a89c4ed823fa6eceb0ceffe13638defa01109a514e639b89e5eafe1a59cbbb4b5cf4b315ef0e2739ca9bdb7d9f0b09b14d105ad1a53dc655176895cacc3f897d5088b004113f886df266edd1ff797f4550885f32380c8fb575be00072239baa70ccf354882e8c50a1d01e81ab2c85146d9e8c3c75140eca2d9d5640af739a86047493e24b1393745914a75fdfe19f081626a5846353c67b45ccf2dd6a753ba118e89239b7916be2ee06e34dc85257228edeaaca06efa0a565580872eff1787360bdf7ff274bb49437bef6a368ab578e34b739ddcc16088a8603ad3700" },
                ResponseTimeOut);

            Assert.Equal(2, result.Length);

            Assert.Contains(result, x =>
                x ==
                "5165dc531aad05d1149bb0f0d9b7bda99c73e2f05e314bcfb5b4bb9ca5e1af5e");

            Assert.Contains(result, x =>
                x ==
                "a5f972572ee1753e2fd2457dd61ce5f40fa2f8a30173d417e49feef7542c96a1");
        }
    }
}

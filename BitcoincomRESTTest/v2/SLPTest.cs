using System.Linq;
using System.Numerics;
using BitcoincomREST.v2;
using BitcoincomREST.v2.Model;
using Xunit;

namespace BitcoincomRESTTest.v2
{
    public class SLPTest
    {
        private const int ResponseTimeOut = 30000;

        [Fact]
        public void GetAllSLPTokensInfoShouldReturn()
        {
            var result = SLP.GetAllSLPTokensInfo(ResponseTimeOut);

            // ensure only version 1 tokens are returned
            Assert.All(result, x => Assert.Equal(1, x.VersionType));
            // ensure all decimals are between 0 and 9 inclusive
            Assert.All(result, x => Assert.True(x.Decimals >= 0 && x.Decimals <= 9));
            // ensure all ids are 64 characters long (32byte hash as hex)
            Assert.All(result, x => Assert.Equal(64, x.TokenId.Length));

            // if no baton was created, ensure all total minted and initial token qty are the same
            Assert.All(result.Where(x => x.MintingBatonStatus == SLPTokenInfo.MintingBatonState.NEVER_CREATED),
                x => Assert.True(x.TotalMinted == x.InitialTokenQty));

            Assert.Contains(result,
                x => x.TokenId == "8fc284dcbc922f7bb7e2a443dc3af792f52923bba403fcf67ca028c88e89da0e");

            var result1 = result.First(x =>
                x.TokenId == "8fc284dcbc922f7bb7e2a443dc3af792f52923bba403fcf67ca028c88e89da0e");
            Assert.Equal("2019-04-29 08:59", result1.Timestamp);
            Assert.Equal("", result1.DocumentUri);
            Assert.Equal("WMW", result1.Symbol);
            Assert.Equal("WheresMyWallet", result1.Name);
            Assert.False(result1.ContainsBaton);
            Assert.Null(result1.DocumentHash);
            Assert.Equal(1000, result1.InitialTokenQty);
            Assert.Equal(580336UL, result1.BlockCreated);
            Assert.True(result1.BlockLastActiveSend >= 580336UL);
            Assert.Null(result1.BlockLastActiveMint);
            Assert.True(result1.TxnsSinceGenesis >= 1);
            Assert.Equal(1000UL, result1.TotalMinted);


            Assert.Contains(result,
                x => x.TokenId == "e670197af3ac79b916cf2b6afd5d96b30add6813da9eca67c42cb668345801ad");

            result1 = result.First(x =>
                x.TokenId == "e670197af3ac79b916cf2b6afd5d96b30add6813da9eca67c42cb668345801ad");
            Assert.Equal(0, result1.Decimals);
            Assert.Equal("2019-04-26 15:23", result1.Timestamp);
            Assert.Equal("", result1.DocumentUri);
            Assert.Equal("OAT", result1.Symbol);
            Assert.Equal("Official Affiliate Token", result1.Name);
            Assert.True(result1.ContainsBaton);
            Assert.Null(result1.DocumentHash);
            Assert.Equal(1000, result1.InitialTokenQty);
            Assert.Equal(579963UL, result1.BlockCreated);
            Assert.True(result1.BlockLastActiveSend >= 579963UL);
            Assert.True(result1.BlockLastActiveMint >= 579963UL);
            Assert.True(result1.TxnsSinceGenesis >= 1);
            Assert.Equal(2000UL, result1.TotalMinted);
            Assert.Equal(2000UL, result1.TotalBurned);
            Assert.Equal(0UL, result1.CirculatingSupply);
            Assert.Equal(SLPTokenInfo.MintingBatonState.DEAD_BURNED, result1.MintingBatonStatus);

            Assert.Contains(result,
                x => x.TokenId == "fa6c74c52450fc164e17402a46645ce494a8a8e93b1383fa27460086931ef59f");


            result1 = result.First(x =>
                x.TokenId == "fa6c74c52450fc164e17402a46645ce494a8a8e93b1383fa27460086931ef59f");
            Assert.Equal(0, result1.Decimals);
            Assert.Equal("2019-02-18 14:47", result1.Timestamp);
            Assert.Equal("https://simpleledger.cash", result1.DocumentUri);
            Assert.Equal("SLP", result1.Symbol);
            Assert.Equal("Official SLP Token", result1.Name);
            Assert.Null(result1.DocumentHash);
            Assert.Equal(0, result1.Decimals);
            Assert.Equal(BigInteger.Parse("18446744073709552000"), result1.InitialTokenQty);
            Assert.Equal(570305UL, result1.BlockCreated);
            Assert.True(result1.BlockLastActiveSend >= 580551UL);
            Assert.True(result1.BlockLastActiveMint >= 575914UL);
            Assert.True(result1.TxnsSinceGenesis >= 4555);
            Assert.True(result1.ContainsBaton,
                "Probably not a problem is this is broken. simpleledger.cash might have destroyed the baton."); // this could change... 
            Assert.Equal(SLPTokenInfo.MintingBatonState.ALIVE, result1.MintingBatonStatus); // this could change... 
        }


        [Fact]
        public void GetSLPTokenInfoShouldReturn()
        {
            var result1 = SLP.GetSLPTokenInfo("8fc284dcbc922f7bb7e2a443dc3af792f52923bba403fcf67ca028c88e89da0e",
                ResponseTimeOut);

            Assert.Equal("2019-04-29 08:59", result1.Timestamp);
            Assert.Equal("", result1.DocumentUri);
            Assert.Equal("WMW", result1.Symbol);
            Assert.Equal("WheresMyWallet", result1.Name);
            Assert.False(result1.ContainsBaton);
            Assert.Null(result1.DocumentHash);
            Assert.Equal(1000, result1.InitialTokenQty);
            Assert.Equal(580336UL, result1.BlockCreated);
            Assert.True(result1.BlockLastActiveSend >= 580336UL);
            Assert.Null(result1.BlockLastActiveMint);
            Assert.True(result1.TxnsSinceGenesis >= 1);
            Assert.Equal(1000UL, result1.TotalMinted);
        }

        [Fact]
        public void GetSLPTokensInfoShouldReturn()
        {
            var result = SLP.GetSLPTokensInfo(new[]
            {
                "8fc284dcbc922f7bb7e2a443dc3af792f52923bba403fcf67ca028c88e89da0e",
                "e670197af3ac79b916cf2b6afd5d96b30add6813da9eca67c42cb668345801ad"
            }, ResponseTimeOut);

            // ensure only version 1 tokens are returned
            Assert.All(result, x => Assert.Equal(1, x.VersionType));
            // ensure all decimals are between 0 and 9 inclusive
            Assert.All(result, x => Assert.True(x.Decimals >= 0 && x.Decimals <= 9));
            // ensure all ids are 64 characters long (32byte hash as hex)
            Assert.All(result, x => Assert.Equal(64, x.TokenId.Length));

            // if no baton was created, ensure all total minted and initial token qty are the same
            Assert.All(result.Where(x => x.MintingBatonStatus == SLPTokenInfo.MintingBatonState.NEVER_CREATED),
                x => Assert.True(x.TotalMinted == x.InitialTokenQty));

            Assert.Contains(result,
                x => x.TokenId == "8fc284dcbc922f7bb7e2a443dc3af792f52923bba403fcf67ca028c88e89da0e");

            var result1 = result.First(x =>
                x.TokenId == "8fc284dcbc922f7bb7e2a443dc3af792f52923bba403fcf67ca028c88e89da0e");
            Assert.Equal("2019-04-29 08:59", result1.Timestamp);
            Assert.Equal("", result1.DocumentUri);
            Assert.Equal("WMW", result1.Symbol);
            Assert.Equal("WheresMyWallet", result1.Name);
            Assert.False(result1.ContainsBaton);
            Assert.Null(result1.DocumentHash);
            Assert.Equal(1000, result1.InitialTokenQty);
            Assert.Equal(580336UL, result1.BlockCreated);
            Assert.True(result1.BlockLastActiveSend >= 580336UL);
            Assert.Null(result1.BlockLastActiveMint);
            Assert.True(result1.TxnsSinceGenesis >= 1);
            Assert.Equal(1000UL, result1.TotalMinted);

            Assert.Contains(result,
                x => x.TokenId == "e670197af3ac79b916cf2b6afd5d96b30add6813da9eca67c42cb668345801ad");

            result1 = result.First(x =>
                x.TokenId == "e670197af3ac79b916cf2b6afd5d96b30add6813da9eca67c42cb668345801ad");
            Assert.Equal(0, result1.Decimals);
            Assert.Equal("2019-04-26 15:23", result1.Timestamp);
            Assert.Equal("", result1.DocumentUri);
            Assert.Equal("OAT", result1.Symbol);
            Assert.Equal("Official Affiliate Token", result1.Name);
            Assert.True(result1.ContainsBaton);
            Assert.Null(result1.DocumentHash);
            Assert.Equal(1000, result1.InitialTokenQty);
            Assert.Equal(579963UL, result1.BlockCreated);
            Assert.True(result1.BlockLastActiveSend >= 579963UL);
            Assert.True(result1.BlockLastActiveMint >= 579963UL);
            Assert.True(result1.TxnsSinceGenesis >= 1);
            Assert.Equal(2000UL, result1.TotalMinted);
            Assert.Equal(2000UL, result1.TotalBurned);
            Assert.Equal(0UL, result1.CirculatingSupply);
            Assert.Equal(SLPTokenInfo.MintingBatonState.DEAD_BURNED, result1.MintingBatonStatus);
        }

        [Fact(Skip =
            "Endpoint is bugged - first query for an address works, but subsequent queries provide incorrect results.")]
        public void GetBalanceShouldReturn()
        {
            var result = SLP.GetBalance("c76bb6046810ee64c29b14c00ef146f223a127551a3fdb10d2f6ab460e8f2325",
                "simpleledger:qzmh8n3hkdsangxxzm04dn3c9exytma3euymt7un20", ResponseTimeOut);

            Assert.Equal("c76bb6046810ee64c29b14c00ef146f223a127551a3fdb10d2f6ab460e8f2325", result.TokenId);
            Assert.Equal(20000, result.Balance);

            result = SLP.GetBalance("fa6c74c52450fc164e17402a46645ce494a8a8e93b1383fa27460086931ef59f",
                "simpleledger:qzmh8n3hkdsangxxzm04dn3c9exytma3euymt7un20", ResponseTimeOut);

            Assert.Equal("fa6c74c52450fc164e17402a46645ce494a8a8e93b1383fa27460086931ef59f", result.TokenId);
            Assert.Equal(1, result.Balance);
        }

        [Fact]
        public void GetBalancesForAddressShouldReturn()
        {
            var result = SLP.GetBalancesForAddress("simpleledger:qzmh8n3hkdsangxxzm04dn3c9exytma3euymt7un20",
                ResponseTimeOut);

            Assert.All(result,
                x => Assert.Equal("simpleledger:qzmh8n3hkdsangxxzm04dn3c9exytma3euymt7un20", x.SLPAddress));

            Assert.Contains(result,
                x => x.TokenId == "c76bb6046810ee64c29b14c00ef146f223a127551a3fdb10d2f6ab460e8f2325");

            var result1 = result.First(x =>
                x.TokenId == "c76bb6046810ee64c29b14c00ef146f223a127551a3fdb10d2f6ab460e8f2325");

            Assert.Equal(20000, result1.Balance);
            Assert.Equal(8, result1.DecimalCount);


            Assert.Contains(result,
                x => x.TokenId == "fa6c74c52450fc164e17402a46645ce494a8a8e93b1383fa27460086931ef59f");

            result1 = result.First(x =>
                x.TokenId == "fa6c74c52450fc164e17402a46645ce494a8a8e93b1383fa27460086931ef59f");

            Assert.Equal(1, result1.Balance);
            Assert.Equal(0, result1.DecimalCount);
        }

        [Fact]
        public void GetBalancesForTokenShouldReturn()
        {
            var result = SLP.GetBalancesForToken("fa6c74c52450fc164e17402a46645ce494a8a8e93b1383fa27460086931ef59f",
                ResponseTimeOut);

            // all results should be for the same tokenId
            Assert.All(result,
                x => Assert.Equal("fa6c74c52450fc164e17402a46645ce494a8a8e93b1383fa27460086931ef59f", x.TokenId));
            // token has no decimals, so ensure all balances are whole numbers
            Assert.All(result, x => Assert.Equal(0, x.TokenBalance % 1));

            Assert.Contains(result, x => x.SLPAddress == "simpleledger:qzmh8n3hkdsangxxzm04dn3c9exytma3euymt7un20");

            var result1 = result.First(x => x.SLPAddress == "simpleledger:qzmh8n3hkdsangxxzm04dn3c9exytma3euymt7un20");

            Assert.Equal(1, result1.TokenBalance);

            result = SLP.GetBalancesForToken("c76bb6046810ee64c29b14c00ef146f223a127551a3fdb10d2f6ab460e8f2325",
                ResponseTimeOut);

            // all results should be for the same tokenId
            Assert.All(result,
                x => Assert.Equal("c76bb6046810ee64c29b14c00ef146f223a127551a3fdb10d2f6ab460e8f2325", x.TokenId));

            Assert.Contains(result, x => x.SLPAddress == "simpleledger:qzmh8n3hkdsangxxzm04dn3c9exytma3euymt7un20");

            result1 = result.First(x => x.SLPAddress == "simpleledger:qzmh8n3hkdsangxxzm04dn3c9exytma3euymt7un20");

            Assert.Equal(20000, result1.TokenBalance);
        }
        
        [Fact]
        public void GetTransactionShouldReturn()
        {
            var result = SLP.GetTransaction("566b52a83242b5b2e04f0cbec296cecb4c50f61c14c23c0ee73bd5234c68a378",
                ResponseTimeOut);

            Assert.Equal("566b52a83242b5b2e04f0cbec296cecb4c50f61c14c23c0ee73bd5234c68a378", result.Txid);
            Assert.Equal(SLPMessageType.SEND, result.TokenInfo.TransactionType);
            Assert.Equal("c76bb6046810ee64c29b14c00ef146f223a127551a3fdb10d2f6ab460e8f2325",
                result.TokenInfo.TokenIdHex);
            Assert.Equal(3, result.TokenInfo.SendOutputs.Length);
            Assert.Equal("0", result.TokenInfo.SendOutputs[0]);
            Assert.Equal("5000000000000", result.TokenInfo.SendOutputs[1]);
            Assert.Equal("90500000000000", result.TokenInfo.SendOutputs[2]);


            result = SLP.GetTransaction("fa6c74c52450fc164e17402a46645ce494a8a8e93b1383fa27460086931ef59f",
                ResponseTimeOut);

            Assert.Equal("fa6c74c52450fc164e17402a46645ce494a8a8e93b1383fa27460086931ef59f", result.Txid);
            Assert.Equal(SLPMessageType.GENESIS, result.TokenInfo.TransactionType);

            // TODO: handle and test GENESIS, MINT, and COMMIT objects
        }

        [Fact]
        public void ValidateTxidShouldReturn()
        {
            var result = SLP.ValidateTxid("566b52a83242b5b2e04f0cbec296cecb4c50f61c14c23c0ee73bd5234c68a378",
                ResponseTimeOut);

            Assert.Equal("566b52a83242b5b2e04f0cbec296cecb4c50f61c14c23c0ee73bd5234c68a378", result.Txid);
            Assert.True(result.Valid);

            result = SLP.ValidateTxid("fb0eeaa501a6e1acb721669c62a3f70741f48ae0fd7f4b8e1d72088785c51952",
                ResponseTimeOut);

            Assert.Equal("fb0eeaa501a6e1acb721669c62a3f70741f48ae0fd7f4b8e1d72088785c51952", result.Txid);
            Assert.True(result.Valid);
        }

        [Fact]
        public void ValidateTxidsShouldReturn()
        {
            var result = SLP.ValidateTxids(new []{"566b52a83242b5b2e04f0cbec296cecb4c50f61c14c23c0ee73bd5234c68a378",
                    "fb0eeaa501a6e1acb721669c62a3f70741f48ae0fd7f4b8e1d72088785c51952" },
                ResponseTimeOut);

            Assert.All(result, x => Assert.True(x.Valid));

            Assert.Contains(result,
                x => x.Txid == "566b52a83242b5b2e04f0cbec296cecb4c50f61c14c23c0ee73bd5234c68a378");

            Assert.Contains(result,
                x => x.Txid == "fb0eeaa501a6e1acb721669c62a3f70741f48ae0fd7f4b8e1d72088785c51952");


            result = SLP.ValidateTxids(new[]{ "566b52a83242b5b2e04f0cbec296cecb4c50f61c14c23c0ee73bd5234c68a378",
                    "80e4387a625f3424b1e271eae3b613de287fb438fb0d7882b172a3daf69c1550" },
                ResponseTimeOut);

            Assert.Contains(result, x => x.Valid);
            Assert.Contains(result, x => !x.Valid);

            Assert.Contains(result,
                x => x.Txid == "566b52a83242b5b2e04f0cbec296cecb4c50f61c14c23c0ee73bd5234c68a378");

            Assert.Contains(result,
                x => x.Txid == "80e4387a625f3424b1e271eae3b613de287fb438fb0d7882b172a3daf69c1550");
        }
    }
}
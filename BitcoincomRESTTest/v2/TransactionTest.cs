using System.Linq;
using BitcoincomREST.v2;
using Xunit;

namespace BitcoincomRESTTest.v2
{
    public class TransactionTest
    {
        private const int ResponseTimeOut = 30000;

        [Fact]
        public void GetTransactionInfoShouldReturn()
        {
            var result = Transaction.GetTransactionInfo("fe28050b93faea61fa88c4c630f0e1f0a1c24d0082dd0e10d369e13212128f33", ResponseTimeOut);

            Assert.Equal("fe28050b93faea61fa88c4c630f0e1f0a1c24d0082dd0e10d369e13212128f33", result.Txid);
            Assert.Equal(1, result.Version);
            Assert.Equal(0, result.LockTime);
            Assert.Single(result.Inputs);
            Assert.Equal("04ffff001d02fd04", result.Inputs[0].Coinbase);
            Assert.Equal(4294967295, result.Inputs[0].Sequence);
            Assert.Equal(0, result.Inputs[0].N);
            Assert.Single(result.Outputs);
            Assert.Equal(50, result.Outputs[0].Value);
            Assert.Equal(0, result.Outputs[0].Position);
            Assert.Single(result.Outputs[0].ScriptPubKey.Addresses);
            Assert.Equal("1BW18n7MfpU35q4MTBSk8pse3XzQF8XvzT", result.Outputs[0].ScriptPubKey.Addresses[0]);
            Assert.Single(result.Outputs[0].ScriptPubKey.CashAddresses);
            Assert.Equal("bitcoincash:qpej6mkrwca4tvy2snq4crhrf88v4ljspysx0ueetk", result.Outputs[0].ScriptPubKey.CashAddresses[0]);
            Assert.Equal("00000000c937983704a73af28acdec37b049d214adbda81d7e2a3dd146f6ed09", result.BlockHash);
            Assert.Equal(1000, result.BlockHeight);
            Assert.True(result.Confirmations > 578997);
            Assert.Equal(1232346882, result.Time);
            Assert.Equal(1232346882, result.BlockTime);
            Assert.True(result.IsCoinBase);
            Assert.Equal(50, result.ValueOut);
            Assert.Equal(135, result.Size);
        }

        [Fact]
        public void GetTransactionInfoMultiShouldReturn()
        {
            var result = Transaction.GetTransactionInfo(new []{"fe28050b93faea61fa88c4c630f0e1f0a1c24d0082dd0e10d369e13212128f33", "5165dc531aad05d1149bb0f0d9b7bda99c73e2f05e314bcfb5b4bb9ca5e1af5e"}, ResponseTimeOut);

            Assert.Equal(2, result.Length);

            Assert.Contains(result, x => x.Txid == "fe28050b93faea61fa88c4c630f0e1f0a1c24d0082dd0e10d369e13212128f33");

            var result1 =
                result.First(x => x.Txid == "fe28050b93faea61fa88c4c630f0e1f0a1c24d0082dd0e10d369e13212128f33");

            Assert.Equal("fe28050b93faea61fa88c4c630f0e1f0a1c24d0082dd0e10d369e13212128f33", result1.Txid);
            Assert.Equal(1, result1.Version);
            Assert.Equal(0, result1.LockTime);
            Assert.Single(result1.Inputs);
            Assert.Equal("04ffff001d02fd04", result1.Inputs[0].Coinbase);
            Assert.Equal(4294967295, result1.Inputs[0].Sequence);
            Assert.Equal(0, result1.Inputs[0].N);
            Assert.Single(result1.Outputs);
            Assert.Equal(50, result1.Outputs[0].Value);
            Assert.Equal(0, result1.Outputs[0].Position);
            Assert.Single(result1.Outputs[0].ScriptPubKey.Addresses);
            Assert.Equal("1BW18n7MfpU35q4MTBSk8pse3XzQF8XvzT", result1.Outputs[0].ScriptPubKey.Addresses[0]);
            Assert.Single(result1.Outputs[0].ScriptPubKey.CashAddresses);
            Assert.Equal("bitcoincash:qpej6mkrwca4tvy2snq4crhrf88v4ljspysx0ueetk", result1.Outputs[0].ScriptPubKey.CashAddresses[0]);
            Assert.Equal("00000000c937983704a73af28acdec37b049d214adbda81d7e2a3dd146f6ed09", result1.BlockHash);
            Assert.Equal(1000, result1.BlockHeight);
            Assert.True(result1.Confirmations > 578997);
            Assert.Equal(1232346882, result1.Time);
            Assert.Equal(1232346882, result1.BlockTime);
            Assert.True(result1.IsCoinBase);
            Assert.Equal(50, result1.ValueOut);
            Assert.Equal(135, result1.Size);
            
            Assert.Contains(result, x => x.Txid == "5165dc531aad05d1149bb0f0d9b7bda99c73e2f05e314bcfb5b4bb9ca5e1af5e");

            var result2 =
                result.First(x => x.Txid == "5165dc531aad05d1149bb0f0d9b7bda99c73e2f05e314bcfb5b4bb9ca5e1af5e");

            Assert.Equal("5165dc531aad05d1149bb0f0d9b7bda99c73e2f05e314bcfb5b4bb9ca5e1af5e", result2.Txid);
            Assert.Equal(1, result2.Version);
            Assert.Equal(0, result2.LockTime);
            Assert.Single(result2.Inputs);
            Assert.Equal("287494433cb225a988f07d1d937938f3bb6e34bcb447fef23e293ef6aa08a126", result2.Inputs[0].Txid);
            Assert.Equal(4294967295, result2.Inputs[0].Sequence);
            Assert.Equal(1, result2.Inputs[0].VOut);
            Assert.Equal(0, result2.Inputs[0].N);
            Assert.Equal(2, result2.Outputs.Length);
            Assert.Equal(0.00031988, result2.Outputs[0].Value);
            Assert.Equal(0, result2.Outputs[0].Position);
            Assert.Single(result2.Outputs[0].ScriptPubKey.Addresses);
            Assert.Equal("115SzregxVDqHDfMPtHjsqYfM8cbmfR4Ji", result2.Outputs[0].ScriptPubKey.Addresses[0]);
            Assert.Single(result2.Outputs[0].ScriptPubKey.CashAddresses);
            Assert.Equal("bitcoincash:qqqdwhvs83t7gx88rz3d4wvc53q6wyt70qe2wxnkgg", result2.Outputs[0].ScriptPubKey.CashAddresses[0]);
            Assert.Equal("000000000000000000bdc52a11408781f1f41b744ee8e5c43df8cda242f09144", result2.BlockHash);
            Assert.Equal(556344, result2.BlockHeight);
            Assert.True(result2.Confirmations > 23655);
            Assert.Equal(1542037792, result2.Time);
            Assert.Equal(1542037792, result2.BlockTime);
            Assert.False(result2.IsCoinBase);
            Assert.Equal(0.00041988, result2.ValueOut);
            Assert.Equal(226, result2.Size);
            Assert.Equal(0.00042231, result2.ValueIn);
            Assert.Equal(0.00000243, result2.Fees);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using BitcoincomREST.v2;
using Xunit;

namespace BitcoincomRESTTest.v2
{
    public class RawTransactionsTest
    {
        private const int ResponseTimeOut = 30000;

        [Fact]
        public void DecodeRawTransactionShouldReturn()
        {
            var result = RawTransactions.DecodeRawTransaction("01000000013ba3edfd7a7b12b27ac72c3e67768f617fc81bc3888a51323a9fb8aa4b1e5e4a000000006a4730440220540986d1c58d6e76f8f05501c520c38ce55393d0ed7ed3c3a82c69af04221232022058ea43ed6c05fec0eccce749a63332ed4525460105346f11108b9c26df93cd72012103083dfc5a0254613941ddc91af39ff90cd711cdcde03a87b144b883b524660c39ffffffff01807c814a000000001976a914d7e7c4e0b70eaa67ceff9d2823d1bbb9f6df9a5188ac00000000", ResponseTimeOut);

            Assert.Equal("d86c34adaeae19171fd98fe0ffd89bfb92a1e6f0339f5e4f18d837715fd25758", result.Txid);
            Assert.Equal("d86c34adaeae19171fd98fe0ffd89bfb92a1e6f0339f5e4f18d837715fd25758", result.Hash);
            Assert.Equal(191, result.Size);
            Assert.Equal(1, result.Version);
            Assert.Equal(0, result.LockTime);
            Assert.Single(result.Inputs);
            Assert.Equal("4a5e1e4baab89f3a32518a88c31bc87f618f76673e2cc77ab2127b7afdeda33b", result.Inputs[0].Txid);
            Assert.Equal(0, result.Inputs[0].VOut);
            Assert.Equal("4730440220540986d1c58d6e76f8f05501c520c38ce55393d0ed7ed3c3a82c69af04221232022058ea43ed6c05fec0eccce749a63332ed4525460105346f11108b9c26df93cd72012103083dfc5a0254613941ddc91af39ff90cd711cdcde03a87b144b883b524660c39", result.Inputs[0].ScriptSig.Hex);
            Assert.Equal("30440220540986d1c58d6e76f8f05501c520c38ce55393d0ed7ed3c3a82c69af04221232022058ea43ed6c05fec0eccce749a63332ed4525460105346f11108b9c26df93cd72[ALL] 03083dfc5a0254613941ddc91af39ff90cd711cdcde03a87b144b883b524660c39", result.Inputs[0].ScriptSig.Script);
            Assert.Equal(4294967295, result.Inputs[0].Sequence);

            Assert.Single(result.Outputs);
            Assert.Equal(12.5, result.Outputs[0].Value);
            Assert.Equal(0, result.Outputs[0].Position);
            Assert.Equal("76a914d7e7c4e0b70eaa67ceff9d2823d1bbb9f6df9a5188ac", result.Outputs[0].ScriptPubKey.Hex);
            Assert.Equal("OP_DUP OP_HASH160 d7e7c4e0b70eaa67ceff9d2823d1bbb9f6df9a51 OP_EQUALVERIFY OP_CHECKSIG", result.Outputs[0].ScriptPubKey.ScriptAsm);
            Assert.Equal(1, result.Outputs[0].ScriptPubKey.RegSigs);
            Assert.Equal("pubkeyhash", result.Outputs[0].ScriptPubKey.Type);
            Assert.Single(result.Outputs[0].ScriptPubKey.Addresses);
            Assert.Equal("bitcoincash:qrt7038qku825e7wl7wjsg73hwuldhu62yz9t0u9ng", result.Outputs[0].ScriptPubKey.Addresses[0]);
        }

        [Fact(Skip = "Multiple Decode Raw Transactions is Broken! Returns the same result multiple times!")]
        public void DecodeRawTransactionMultiShouldReturn()
        {
            var result = RawTransactions.DecodeRawTransactions(new [] {"01000000013ba3edfd7a7b12b27ac72c3e67768f617fc81bc3888a51323a9fb8aa4b1e5e4a000000006a4730440220540986d1c58d6e76f8f05501c520c38ce55393d0ed7ed3c3a82c69af04221232022058ea43ed6c05fec0eccce749a63332ed4525460105346f11108b9c26df93cd72012103083dfc5a0254613941ddc91af39ff90cd711cdcde03a87b144b883b524660c39ffffffff01807c814a000000001976a914d7e7c4e0b70eaa67ceff9d2823d1bbb9f6df9a5188ac00000000",
                "01000000017b1eabe0209b1fe794124575ef807057c77ada2138ae4fa8d6c4de0398a14f3f0000000000ffffffff01f0ca052a010000001976a914cbc20a7664f2f69e5355aa427045bc15e7c6c77288ac00000000"},ResponseTimeOut);

            Assert.Equal(2, result.Length);

            Assert.Contains(result, x => x.Txid == "d86c34adaeae19171fd98fe0ffd89bfb92a1e6f0339f5e4f18d837715fd25758");

            var result1 = result[0];

            Assert.Equal("d86c34adaeae19171fd98fe0ffd89bfb92a1e6f0339f5e4f18d837715fd25758", result1.Txid);
            Assert.Equal("d86c34adaeae19171fd98fe0ffd89bfb92a1e6f0339f5e4f18d837715fd25758", result1.Hash);
            Assert.Equal(191, result1.Size);
            Assert.Equal(1, result1.Version);
            Assert.Equal(0, result1.LockTime);
            Assert.Single(result1.Inputs);
            Assert.Equal("4a5e1e4baab89f3a32518a88c31bc87f618f76673e2cc77ab2127b7afdeda33b", result1.Inputs[0].Txid);
            Assert.Equal(0, result1.Inputs[0].VOut);
            Assert.Equal("4730440220540986d1c58d6e76f8f05501c520c38ce55393d0ed7ed3c3a82c69af04221232022058ea43ed6c05fec0eccce749a63332ed4525460105346f11108b9c26df93cd72012103083dfc5a0254613941ddc91af39ff90cd711cdcde03a87b144b883b524660c39", result1.Inputs[0].ScriptSig.Hex);
            Assert.Equal("30440220540986d1c58d6e76f8f05501c520c38ce55393d0ed7ed3c3a82c69af04221232022058ea43ed6c05fec0eccce749a63332ed4525460105346f11108b9c26df93cd72[ALL] 03083dfc5a0254613941ddc91af39ff90cd711cdcde03a87b144b883b524660c39", result1.Inputs[0].ScriptSig.Script);
            Assert.Equal(4294967295, result1.Inputs[0].Sequence);

            Assert.Single(result1.Outputs);
            Assert.Equal(12.5, result1.Outputs[0].Value);
            Assert.Equal(0, result1.Outputs[0].Position);
            Assert.Equal("76a914d7e7c4e0b70eaa67ceff9d2823d1bbb9f6df9a5188ac", result1.Outputs[0].ScriptPubKey.Hex);
            Assert.Equal("OP_DUP OP_HASH160 d7e7c4e0b70eaa67ceff9d2823d1bbb9f6df9a51 OP_EQUALVERIFY OP_CHECKSIG", result1.Outputs[0].ScriptPubKey.ScriptAsm);
            Assert.Equal(1, result1.Outputs[0].ScriptPubKey.RegSigs);
            Assert.Equal("pubkeyhash", result1.Outputs[0].ScriptPubKey.Type);
            Assert.Single(result1.Outputs[0].ScriptPubKey.Addresses);
            Assert.Equal("bitcoincash:qrt7038qku825e7wl7wjsg73hwuldhu62yz9t0u9ng", result1.Outputs[0].ScriptPubKey.Addresses[0]);

            Assert.Contains(result, x => x.Txid == "c80b343d2ce2b5d829c2de9854c7c8d423c0e33bda264c40138d834aab4c0638");

            var result2 = result[1];

            Assert.Equal("c80b343d2ce2b5d829c2de9854c7c8d423c0e33bda264c40138d834aab4c0638", result2.Txid);
            Assert.Equal("c80b343d2ce2b5d829c2de9854c7c8d423c0e33bda264c40138d834aab4c0638", result2.Hash);
            Assert.Equal(85, result2.Size);
            Assert.Equal(1, result2.Version);
            Assert.Equal(0, result2.LockTime);
            Assert.Single(result2.Inputs);
            Assert.Equal("3f4fa19803dec4d6a84fae3821da7ac7577080ef75451294e71f9b20e0ab1e7b", result2.Inputs[0].Txid);
            Assert.Equal(0, result2.Inputs[0].VOut);
            Assert.Equal("", result2.Inputs[0].ScriptSig.Hex);
            Assert.Equal("", result2.Inputs[0].ScriptSig.Script);
            Assert.Equal(4294967295, result2.Inputs[0].Sequence);

            Assert.Single(result2.Outputs);
            Assert.Equal(49.9999, result2.Outputs[0].Value);
            Assert.Equal(0, result2.Outputs[0].Position);
            Assert.Equal("76a914cbc20a7664f2f69e5355aa427045bc15e7c6c77288ac", result2.Outputs[0].ScriptPubKey.Hex);
            Assert.Equal("OP_DUP OP_HASH160 cbc20a7664f2f69e5355aa427045bc15e7c6c772 OP_EQUALVERIFY OP_CHECKSIG", result2.Outputs[0].ScriptPubKey.ScriptAsm);
            Assert.Equal(1, result2.Outputs[0].ScriptPubKey.RegSigs);
            Assert.Equal("pubkeyhash", result2.Outputs[0].ScriptPubKey.Type);
            Assert.Single(result2.Outputs[0].ScriptPubKey.Addresses);
            Assert.Equal("bitcoincash:qr9uyznkvne0d8jn2k4yyuz9hs2703k8wg2t2ha29q", result2.Outputs[0].ScriptPubKey.Addresses[0]);
        }

        [Fact]
        public void DecodeScriptShouldReturn()
        {
            var result = RawTransactions.DecodeScript("4830450221009a51e00ec3524a7389592bc27bea4af5104a59510f5f0cfafa64bbd5c164ca2e02206c2a8bbb47eabdeed52f17d7df668d521600286406930426e3a9415fe10ed592012102e6e1423f7abde8b70bca3e78a7d030e5efabd3eb35c19302542b5fe7879c1a16", ResponseTimeOut);

            Assert.Equal("30450221009a51e00ec3524a7389592bc27bea4af5104a59510f5f0cfafa64bbd5c164ca2e02206c2a8bbb47eabdeed52f17d7df668d521600286406930426e3a9415fe10ed59201 02e6e1423f7abde8b70bca3e78a7d030e5efabd3eb35c19302542b5fe7879c1a16", result.Asm);
            Assert.Equal("nonstandard", result.Type);
            Assert.Equal("bitcoincash:pqwndulzwft8dlmqrteqyc9hf823xr3lcc7ypt74ts", result.P2SH);
            Assert.Null(result.Addresses);

            result = RawTransactions.DecodeScript("76a9145fb851ac684ccc18abddf25a7a31597543b1059b88ac", ResponseTimeOut);

            Assert.Equal("OP_DUP OP_HASH160 5fb851ac684ccc18abddf25a7a31597543b1059b OP_EQUALVERIFY OP_CHECKSIG", result.Asm);
            Assert.Equal("pubkeyhash", result.Type);
            Assert.Single(result.Addresses);
            Assert.Equal("bitcoincash:qp0ms5dvdpxvcx9tmhe95733t9658vg9nv35vy6ws9", result.Addresses[0]);
            Assert.Equal("bitcoincash:pz3m7mhm6mrlggkv2wlfdv6cc98hqvwpzuyvv4t36e", result.P2SH);
        }

        [Fact (Skip = "Multiple Decode Script is Broken! Returns the same result multiple times!")]
        public void DecodeScriptMultiShouldReturn()
        {
            var result = RawTransactions.DecodeScripts(new[]
            {
                "4830450221009a51e00ec3524a7389592bc27bea4af5104a59510f5f0cfafa64bbd5c164ca2e02206c2a8bbb47eabdeed52f17d7df668d521600286406930426e3a9415fe10ed592012102e6e1423f7abde8b70bca3e78a7d030e5efabd3eb35c19302542b5fe7879c1a16",
                "76a9145fb851ac684ccc18abddf25a7a31597543b1059b88ac"
            }, ResponseTimeOut);

            Assert.Equal(2, result.Length);

            Assert.Contains(result, x => x.P2SH == "bitcoincash:pqwndulzwft8dlmqrteqyc9hf823xr3lcc7ypt74ts");

            var result1 = result[0];

            Assert.Equal("30450221009a51e00ec3524a7389592bc27bea4af5104a59510f5f0cfafa64bbd5c164ca2e02206c2a8bbb47eabdeed52f17d7df668d521600286406930426e3a9415fe10ed59201 02e6e1423f7abde8b70bca3e78a7d030e5efabd3eb35c19302542b5fe7879c1a16", result1.Asm);
            Assert.Equal("nonstandard", result1.Type);
            Assert.Equal("bitcoincash:pqwndulzwft8dlmqrteqyc9hf823xr3lcc7ypt74ts", result1.P2SH);
            Assert.Null(result1.Addresses);

            Assert.Contains(result, x => x.P2SH == "bitcoincash:pz3m7mhm6mrlggkv2wlfdv6cc98hqvwpzuyvv4t36e");

            var result2 = result[1];

            Assert.Equal("OP_DUP OP_HASH160 5fb851ac684ccc18abddf25a7a31597543b1059b OP_EQUALVERIFY OP_CHECKSIG", result2.Asm);
            Assert.Equal("pubkeyhash", result2.Type);
            Assert.Single(result2.Addresses);
            Assert.Equal("bitcoincash:qp0ms5dvdpxvcx9tmhe95733t9658vg9nv35vy6ws9", result2.Addresses[0]);
            Assert.Equal("bitcoincash:pz3m7mhm6mrlggkv2wlfdv6cc98hqvwpzuyvv4t36e", result2.P2SH);
        }

        private readonly Dictionary<string, string> _rawTransactionFromHash = new Dictionary<string, string>()
        {
            ["fe28050b93faea61fa88c4c630f0e1f0a1c24d0082dd0e10d369e13212128f33"] = "01000000010000000000000000000000000000000000000000000000000000000000000000ffffffff0804ffff001d02fd04ffffffff0100f2052a01000000434104f5eeb2b10c944c6b9fbcfff94c35bdeecd93df977882babc7f3a2cf7f5c81d3b09a68db7f0e04f21de5d4230e75e6dbe7ad16eefe0d4325a62067dc6f369446aac00000000",
            ["a5f972572ee1753e2fd2457dd61ce5f40fa2f8a30173d417e49feef7542c96a1"] = "01000000015eafe1a59cbbb4b5cf4b315ef0e2739ca9bdb7d9f0b09b14d105ad1a53dc6551010000006b483045022100cf9869b1e8c5e5da7bb6753a92171ee17c2bb53a5ed1db25b0a056d9ad459e4e022067c47af184c110cf832fa2f86ce1eebf363eb72293cc450f7ae3d82aad9da22c41210299b1eedeb115b5880cd5e0df0717bd982748a8e003e34371dc36301e17ee0ed6ffffffff014d260000000000001976a914e46b114b3908efe7f18cd1435d2e2ffa16a936fd88ac00000000"
        };

        [Fact]
        public void GetRawTransactionShouldReturn()
        {
            foreach (var (hash, rawTx) in _rawTransactionFromHash)
            {
                var result = RawTransactions.GetRawTransaction(hash, ResponseTimeOut);
                Assert.Equal(rawTx, result);
            }
        }

        [Fact]  
        public void GetRawTransactionMultiShouldReturn()
        {
            var result = RawTransactions.GetRawTransactions(_rawTransactionFromHash.Keys.ToArray(), ResponseTimeOut);

            foreach (var rawTx in _rawTransactionFromHash.Values)
                Assert.Contains(rawTx, result);
        }

        [Fact]
        public void GetRawTransactionInfoShouldReturn()
        {
            var result = RawTransactions.GetRawTransactionInfo("fe28050b93faea61fa88c4c630f0e1f0a1c24d0082dd0e10d369e13212128f33", ResponseTimeOut);
            
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
            Assert.Equal("bitcoincash:qpej6mkrwca4tvy2snq4crhrf88v4ljspysx0ueetk", result.Outputs[0].ScriptPubKey.Addresses[0]);
            Assert.Equal("00000000c937983704a73af28acdec37b049d214adbda81d7e2a3dd146f6ed09", result.BlockHash);
            Assert.True(result.Confirmations > 578997);
            Assert.Equal(1232346882, result.Time);
            Assert.Equal(1232346882, result.BlockTime);
            Assert.Equal(135, result.Size);
        }

        [Fact]
        public void GetRawTransactionInfoMultiShouldReturn()
        {
            var result = RawTransactions.GetRawTransactionInfo(new[] { "fe28050b93faea61fa88c4c630f0e1f0a1c24d0082dd0e10d369e13212128f33", "a5f972572ee1753e2fd2457dd61ce5f40fa2f8a30173d417e49feef7542c96a1" }, ResponseTimeOut);

            Assert.Equal(2, result.Length);

            Assert.Contains(result,
                x => x.Hash == "fe28050b93faea61fa88c4c630f0e1f0a1c24d0082dd0e10d369e13212128f33");

            var result1 = result.First(x => x.Hash == "fe28050b93faea61fa88c4c630f0e1f0a1c24d0082dd0e10d369e13212128f33");

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
            Assert.Equal("bitcoincash:qpej6mkrwca4tvy2snq4crhrf88v4ljspysx0ueetk", result1.Outputs[0].ScriptPubKey.Addresses[0]);
            Assert.Equal("00000000c937983704a73af28acdec37b049d214adbda81d7e2a3dd146f6ed09", result1.BlockHash);
            Assert.True(result1.Confirmations > 578997);
            Assert.Equal(1232346882, result1.Time);
            Assert.Equal(1232346882, result1.BlockTime);
            Assert.Equal(135, result1.Size);

            Assert.Contains(result,
                x => x.Hash == "a5f972572ee1753e2fd2457dd61ce5f40fa2f8a30173d417e49feef7542c96a1");

            var result2 = result.First(x => x.Hash == "a5f972572ee1753e2fd2457dd61ce5f40fa2f8a30173d417e49feef7542c96a1");

            Assert.Equal("a5f972572ee1753e2fd2457dd61ce5f40fa2f8a30173d417e49feef7542c96a1", result2.Txid);
            Assert.Equal(1, result2.Version);
            Assert.Equal(0, result2.LockTime);
            Assert.Single(result2.Inputs);
            Assert.Equal("5165dc531aad05d1149bb0f0d9b7bda99c73e2f05e314bcfb5b4bb9ca5e1af5e", result2.Inputs[0].Txid);
            Assert.Equal(4294967295, result2.Inputs[0].Sequence);
            Assert.Equal(1, result2.Inputs[0].VOut);
            Assert.Single(result2.Outputs);
            Assert.Equal(0.00009805, result2.Outputs[0].Value);
            Assert.Equal(0, result2.Outputs[0].Position);
            Assert.Single(result2.Outputs[0].ScriptPubKey.Addresses);
            Assert.Equal("bitcoincash:qrjxky2t8yywlel33ng5xhfw9lapd2fkl5p5dj7qsw", result2.Outputs[0].ScriptPubKey.Addresses[0]);
            Assert.Equal("OP_DUP OP_HASH160 e46b114b3908efe7f18cd1435d2e2ffa16a936fd OP_EQUALVERIFY OP_CHECKSIG", result2.Outputs[0].ScriptPubKey.ScriptAsm);
            Assert.Equal("76a914e46b114b3908efe7f18cd1435d2e2ffa16a936fd88ac", result2.Outputs[0].ScriptPubKey.Hex);
            Assert.Equal("pubkeyhash", result2.Outputs[0].ScriptPubKey.Type);
            Assert.Equal(1, result2.Outputs[0].ScriptPubKey.RegSigs);
            Assert.Equal("0000000000000000015a670527f131686736987bc3889bc44674795ed64ef40d", result2.BlockHash);
            Assert.True(result2.Confirmations > 22755);
            Assert.Equal(1542758880, result2.Time);
            Assert.Equal(1542758880, result2.BlockTime);
            Assert.Equal(192, result2.Size);
        }
    }
}
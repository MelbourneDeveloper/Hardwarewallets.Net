using Hardwarewallets.Net.Base;
using LedgerWallet;
using NBitcoin;
using System;
using System.Threading.Tasks;

namespace Hardwarewallets.Net
{
    public class LedgerDotNetApiWrapper : IHardwarewalletManager
    {
        private LedgerClient _LedgerClient;

        public LedgerDotNetApiWrapper(LedgerClient ledgerClient)
        {
            _LedgerClient = ledgerClient;
        }

        public async Task<string> GetAddressAsync(IAddressPath addressPath, bool display)
        {
            if (addressPath.CoinType == 0)
            {
            }
            else
            {
                throw new NotImplementedException();
            }

            var response = await _LedgerClient.GetWalletPubKeyAsync(new KeyPath($"{addressPath.Purpose}'/{addressPath.CoinType}'/{addressPath.Account}'/{addressPath.Change}/{addressPath.AddressIndex}"), LedgerClient.AddressType.Legacy, true);
            return response.Address;
        }

        public Task<string> GetPublicKeyAsync(IAddressPath addressPath, bool display)
        {
            throw new NotImplementedException();
        }

        public Task<T2> SignTransaction<T, T2>(T transaction)
            where T : ITransaction
            where T2 : ISignedTransaction
        {
            throw new NotImplementedException();
        }
    }
}

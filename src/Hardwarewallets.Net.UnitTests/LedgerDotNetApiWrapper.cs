using Hardwarewallets.Net.Model;
using LedgerWallet;
using NBitcoin;
using System;
using System.Threading.Tasks;

namespace Hardwarewallets.Net
{
    public class LedgerDotNetApiWrapper : IAddressDeriver, ITransactionSigner
    {
        #region Fields
        private LedgerClient _LedgerClient;
        #endregion

        #region Constructor
        public LedgerDotNetApiWrapper(LedgerClient ledgerClient)
        {
            _LedgerClient = ledgerClient;
        }
        #endregion

        #region Public Methods
        public async Task<string> GetAddressAsync(IAddressPath addressPath, bool isPublicKey, bool display)
        {
            var response = await GetPublicKey(addressPath, display);
            return isPublicKey ? response.UncompressedPublicKey.ToHex() : response.Address;
        }

        public Task<T2> SignTransaction<T, T2>(T transaction)
            where T : ITransaction
            where T2 : ISignedTransaction
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Private Methods
        private async Task<GetWalletPubKeyResponse> GetPublicKey(IAddressPath addressPath, bool display)
        {
            if (addressPath.CoinType == 0)
            {
            }
            else
            {
                throw new NotImplementedException();
            }

            var response = await _LedgerClient.GetWalletPubKeyAsync(new KeyPath($"{addressPath.Purpose}'/{addressPath.CoinType}'/{addressPath.Account}'/{addressPath.Change}/{addressPath.AddressIndex}"), LedgerClient.AddressType.Legacy, display);
            return response;
        }
        #endregion
    }
}

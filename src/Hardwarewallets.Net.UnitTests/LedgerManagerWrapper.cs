using Hardwarewallets.Net.Model;
using Ledger.Net;
using Ledger.Net.Requests;
using Ledger.Net.Responses;
using System;
using System.Threading.Tasks;

namespace Hardwarewallets.Net
{
    public class LedgerManagerWrapper : IAddressDeriver, ITransactionSigner
    {
        #region Fields
        private LedgerManager _LedgerManager;
        #endregion

        #region Constructor
        public LedgerManagerWrapper(LedgerManager ledgerManager)
        {
            _LedgerManager = ledgerManager;
        }
        #endregion

        #region Public Methods
        public async Task<string> GetAddressAsync(IAddressPath addressPath, bool isPublicKey, bool display)
        {
            var response = await GetPublicKey(addressPath, display);
            return isPublicKey ? response.PublicKey : response.Address;
        }

        public Task<T2> SignTransaction<T, T2>(T transaction)
            where T : ITransaction
            where T2 : ISignedTransaction
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Private Methods
        private async Task<BitcoinAppGetPublicKeyResponse> GetPublicKey(IAddressPath addressPath, bool display)
        {
            if (addressPath.CoinType == 0)
            {
            }
            else
            {
                throw new NotImplementedException();
            }

            var addressPath2 = Helpers.GetDerivationPathData(_LedgerManager.CurrentCoin.App, _LedgerManager.CurrentCoin.CoinNumber, 0, 0, false, _LedgerManager.CurrentCoin.IsSegwit);
            var publicKey = await _LedgerManager.SendRequestAsync<BitcoinAppGetPublicKeyResponse, BitcoinAppGetPublicKeyRequest>(new BitcoinAppGetPublicKeyRequest(display, BitcoinAddressType.Legacy, addressPath2));


            return publicKey;
        }
        #endregion
    }
}

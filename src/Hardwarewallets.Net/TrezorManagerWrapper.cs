using Hardwarewallets.Net.Base;
using System;
using System.Threading.Tasks;
using Trezor.Net;
using Trezor.Net.Contracts;

namespace Hardwarewallets.Net
{
    /// <summary>
    /// TODO: This should be abstract
    /// </summary>
    public class TrezorManagerWrapper<T> : IHardwarewalletManager where T : TrezorManagerBase
    {
        #region Fields
        protected T _TrezorManager;
        #endregion

        #region Constructor
        public TrezorManagerWrapper(T trezorManager)
        {
            _TrezorManager = trezorManager;
        }
        #endregion

        #region Protected Methods
        protected virtual async Task<string> GetAddress(IAddressPath addressPath, bool display, string coinShortcut)
        {
            return await _TrezorManager.GetAddressAsync(coinShortcut, addressPath.CoinType, addressPath.Change == 1 ? true : false, addressPath.AddressIndex, display, AddressType.Bitcoin);
        }
        #endregion

        #region Public Methods (Implementation)
        public async Task<string> GetAddressAsync(IAddressPath addressPath, bool display)
        {
            string coinShortcut = null;
            if (addressPath.CoinType == 0)
            {
                coinShortcut = "BTC";
            }
            else
            {
                throw new NotImplementedException();
            }

            var retVal = await GetAddress(addressPath, display, coinShortcut);

            return retVal;
        }

        /// <summary>
        /// TODO: This should be abstract
        /// </summary>
        public virtual async Task<string> GetPublicKeyAsync(IAddressPath addressPath, bool display)
        {
            var publicKey = await _TrezorManager.SendMessageAsync<PublicKey, GetPublicKey>(new GetPublicKey { AddressNs = addressPath.ToHardenedArray() });
            return publicKey.Xpub;
        }

        public Task<T2> SignTransaction<T, T2>(T transaction)
            where T : ITransaction
            where T2 : ISignedTransaction
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

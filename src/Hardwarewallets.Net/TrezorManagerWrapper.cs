using Hardwarewallets.Net.Base;
using System;
using System.Threading.Tasks;
using Trezor.Net;

namespace Hardwarewallets.Net
{
    public class TrezorManagerWrapper : IHardwarewalletManager
    {
        private TrezorManagerBase _TrezorManager;

        public TrezorManagerWrapper(TrezorManagerBase trezorManager)
        {
            _TrezorManager = trezorManager;
        }

        public Task<string> GetAddressAsync(IAddressPath addressPath, bool display)
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

            return _TrezorManager.GetAddressAsync(coinShortcut, addressPath.CoinType, addressPath.Change == 1 ? true : false, addressPath.AddressIndex, true, AddressType.Bitcoin);
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

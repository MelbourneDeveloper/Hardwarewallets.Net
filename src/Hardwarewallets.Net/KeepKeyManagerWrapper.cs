using Hardwarewallets.Net.Base;
using KeepKey.Net;
using KeepKey.Net.Contracts;
using System.Threading.Tasks;
using Trezor.Net;

namespace Hardwarewallets.Net
{
    public class KeepKeyManagerWrapper : TrezorManagerWrapper<KeepKeyManager>
    {
        public KeepKeyManagerWrapper(KeepKeyManager keepKeyManager) : base(keepKeyManager)
        {
        }

        protected override Task<string> GetAddress(IAddressPath addressPath, bool display, string coinShortcut)
        {
            return _TrezorManager.GetAddressAsync(coinShortcut, addressPath.CoinType, addressPath.Account, addressPath.Change == 1, addressPath.AddressIndex, display, AddressType.Bitcoin, false);
        }

        public override async Task<string> GetPublicKeyAsync(IAddressPath addressPath, bool display)
        {
            var publicKey = await _TrezorManager.SendMessageAsync<PublicKey, GetPublicKey>(new GetPublicKey { AddressNs = addressPath.ToHardenedArray() });
            return publicKey.Xpub;
        }
    }
}

using Hardwarewallets.Net.Model;
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

        public override async Task<string> GetAddressAsync(IAddressPath addressPath, bool isPublicKey, bool display)
        {
            if (isPublicKey)
            {
                var publicKey = await _TrezorManager.SendMessageAsync<PublicKey, GetPublicKey>(new GetPublicKey { AddressNs = addressPath.ToHardenedArray() });
                return publicKey.Xpub;

            }
            else
            {
                return await _TrezorManager.GetAddressAsync(null, addressPath.CoinType, addressPath.Account, addressPath.Change == 1, addressPath.AddressIndex, display, AddressType.Bitcoin, false);
            }
        }

    }
}

using System.Threading.Tasks;

namespace Hardwarewallets.Net.Base
{
    interface IHardwarewalletManager
    {
        Task<string> GetPublicKeyAsync(IAddressPath addressPath, bool display);
        Task<string> GetAddressAsync(IAddressPath addressPath, bool display);
    }
}

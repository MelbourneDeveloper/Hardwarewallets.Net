using System.Threading.Tasks;

namespace Hardwarewallets.Net.Base
{
    public interface IHardwarewalletManager
    {
        Task<string> GetPublicKeyAsync(IAddressPath addressPath, bool display);
        Task<string> GetAddressAsync(IAddressPath addressPath, bool display);
        Task<byte[]> SignTransaction<T>(T transaction) where T : ITransaction;
    }
}

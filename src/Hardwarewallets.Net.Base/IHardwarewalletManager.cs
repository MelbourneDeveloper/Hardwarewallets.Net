using System.Threading.Tasks;

namespace Hardwarewallets.Net.Base
{
    public interface IHardwarewalletManager
    {
        Task<string> GetPublicKeyAsync(IAddressPath addressPath, bool display);
        Task<string> GetAddressAsync(IAddressPath addressPath, bool display);
        Task<T2> SignTransaction<T, T2>(T transaction)
            where T : ITransaction
            where T2 : ISignedTransaction;
    }
}

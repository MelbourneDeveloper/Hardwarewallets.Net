using Hardwarewallets.Net.Model;
using System.Threading.Tasks;

namespace Hardwarewallets.Net
{
    public interface IAddressDeriver
    {
        Task<string> GetAddressAsync(IAddressPath addressPath, bool isPublicKey, bool display);
    }
}

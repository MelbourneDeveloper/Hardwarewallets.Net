using Hardwarewallets.Net.Model;

namespace Hardwarewallets.Net
{
    public interface IAddressPathFactory
    {
        IAddressPath GetAddressPath(uint change, uint account, uint addressIndex);
    }
}

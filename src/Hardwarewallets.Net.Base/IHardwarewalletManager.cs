namespace Hardwarewallets.Net.Base
{
    interface IHardwarewalletManager
    {
        string GetPublicKey(IAddressPath addressPath, bool display);
        string GetAddress(IAddressPath addressPath, bool display);
    }
}

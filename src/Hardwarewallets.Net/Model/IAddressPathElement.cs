namespace Hardwarewallets.Net.Model
{
    public interface IAddressPathElement
    {
        uint UnhardenedValue { get; }
        bool Harden { get; }
    }
}

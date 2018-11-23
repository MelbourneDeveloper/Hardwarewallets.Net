namespace Hardwarewallets.Net.Model
{
    public interface IAddressPathElement
    {
        uint Value { get; }
        bool Harden { get; }
    }
}

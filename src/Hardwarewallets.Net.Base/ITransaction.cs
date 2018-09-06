namespace Hardwarewallets.Net.Base
{
    public interface ITransaction
    {
        IAddressPath From { get; }
        decimal Value { get; }
        string To { get; }
    }
}

namespace Hardwarewallets.Net.Base.Ethereum
{
    public interface ISignedEthereumTransaction
    {
        byte[] SignatureR { get; set; }
        byte[] SignatureS { get; set; }
        byte[] SignatureV { get; set; }
    }
}

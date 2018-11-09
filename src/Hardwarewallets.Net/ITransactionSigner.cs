using Hardwarewallets.Net.Model;

namespace Hardwarewallets.Net
{
    public interface ITransactionSigner<TTransaction, TTransactionRequest> where TTransaction : ITransaction
    {
        TTransactionRequest SignTransction(TTransaction transaction);
    }
}

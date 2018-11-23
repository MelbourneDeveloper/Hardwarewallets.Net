using Hardwarewallets.Net.Model;
using System.Threading.Tasks;

namespace Hardwarewallets.Net
{
    public interface ITransactionSigner<TTransaction, TTransactionRequest> where TTransaction : ITransaction
    {
        Task<TTransactionRequest> SignTransction(TTransaction transaction);
    }
}

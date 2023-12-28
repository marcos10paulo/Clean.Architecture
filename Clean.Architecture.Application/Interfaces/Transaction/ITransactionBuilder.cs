using System.Transactions;

namespace Clean.Architecture.Application.Interfaces.Transaction
{
    public interface ITransactionBuilder
    {
        TransactionScope OpenTransaction();
        TransactionScope OpenTransaction(TransactionScopeOption scopeOption);
        TransactionScope OpenTransaction(TransactionScopeOption scopeOption, IsolationLevel isolationLevel);
    }
}

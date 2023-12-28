using Clean.Architecture.Application.Interfaces.Transaction;
using System.Transactions;

namespace Clean.Architecture.Infra.Generic.Transaction
{
    public class TransactionBuilder : ITransactionBuilder
    {
        public TransactionScope OpenTransaction()
        {
            return OpenTransaction(TransactionScopeOption.Required);
        }

        public TransactionScope OpenTransaction(TransactionScopeOption scopeOption)
        {
            return OpenTransaction(scopeOption, IsolationLevel.ReadCommitted);
        }

        public TransactionScope OpenTransaction(TransactionScopeOption scopeOption, IsolationLevel isolationLevel)
        {
            return new TransactionScope(
                scopeOption,
                new TransactionOptions { IsolationLevel = isolationLevel },
                TransactionScopeAsyncFlowOption.Enabled
            );
        }
    }
}

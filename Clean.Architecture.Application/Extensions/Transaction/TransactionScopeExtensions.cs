using Clean.Architecture.Domain.Validation.ErrorBase;
using System.Transactions;

namespace Clean.Architecture.Application.Extensions.Transaction
{
    public static class TransactionScopeExtensions
    {
        public static Result<string> Commit(this TransactionScope transaction)
        {
            try
            {
                transaction.Complete();
                return Result<string>.Ok("");
            }
            catch (Exception ex)
            {
                return Result<string>.Fail(Error.Unexpected(description: ex.Message + ex.InnerException != null
                    ? "InnerException: \n" + ex.InnerException.Message
                    : ""
                ));
            }
        }

        public static Result<string> Rollback(this TransactionScope transaction)
        {
            transaction?.Dispose();

            return Result<string>.Ok("");
        }
    }
}

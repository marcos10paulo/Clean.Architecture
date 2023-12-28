using Clean.Architecture.Application.Extensions.Transaction;
using Clean.Architecture.Application.Interfaces.Data.Repositories;
using Clean.Architecture.Application.Interfaces.Transaction;
using Clean.Architecture.Application.Interfaces.UseCases.InvoiceCases.Commands;
using Clean.Architecture.Contracts.InvoiceContracts;
using Clean.Architecture.Domain.Entities.InvoiceItemEntity;
using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Application.UseCases.InvoiceCases.Commands
{
    public class InvoiceItemCreateCommand : IInvoiceItemCreateCommand
    {        
        private readonly IInvoiceItemRepository _invoiceItemRepository;
        private readonly ITransactionBuilder _transactionBuilder;

        public InvoiceItemCreateCommand(
            ITransactionBuilder transactionBuilder,
            IInvoiceItemRepository invoiceItemRepository)
        {
            _transactionBuilder = transactionBuilder;
            _invoiceItemRepository = invoiceItemRepository;
        }

        public async Task<Result<InvoiceItem>> Execute(InvoiceItemCreateRequest request, int invoiceId, int? userId = null)
        {
            Result<InvoiceItem> resultInvoiceItem = InvoiceItem.Create(request.Description, request.Amount, invoiceId);

            if (resultInvoiceItem.IsFailure)
                return Result<InvoiceItem>.Fail(resultInvoiceItem.Error);

            using (var transaction = _transactionBuilder.OpenTransaction())
            {
                resultInvoiceItem = await _invoiceItemRepository.Create(resultInvoiceItem.GetValue());

                if (resultInvoiceItem.IsFailure)
                {
                    transaction.Rollback();
                    return Result<InvoiceItem>.Fail(resultInvoiceItem.Error);
                }

                InvoiceItem invoiceItem = resultInvoiceItem.GetValue();

                transaction.Commit();

                return Result<InvoiceItem>.Ok(invoiceItem);
            }
        }
    }
}

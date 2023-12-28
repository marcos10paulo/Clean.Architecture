using Clean.Architecture.Application.Extensions.Transaction;
using Clean.Architecture.Application.Interfaces.Data.Repositories;
using Clean.Architecture.Application.Interfaces.Transaction;
using Clean.Architecture.Application.Interfaces.UseCases.InvoiceCases.Commands;
using Clean.Architecture.Contracts.InvoiceContracts;
using Clean.Architecture.Domain.Entities.InvoiceItemEntity;
using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Application.UseCases.InvoiceItemCases.Commands
{
    public class InvoiceItemUpdateCommand: IInvoiceItemUpdateCommand
    {
        private readonly IInvoiceItemRepository _invoiceItemRepository;
        private readonly ITransactionBuilder _transactionBuilder;

        public InvoiceItemUpdateCommand(
            ITransactionBuilder transactionBuilder,
            IInvoiceItemRepository invoiceItemRepository)
        {
            _transactionBuilder = transactionBuilder;
            _invoiceItemRepository = invoiceItemRepository;
        }

        public async Task<Result<InvoiceItem>> Execute(InvoiceItemUpdateRequest request, int? userId = null)
        {
            Result<InvoiceItem> resultInvoiceItem = InvoiceItem.Create(request.Description, request.Amount, request.InvoiceId);

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

        public async Task<Result<IEnumerable<InvoiceItem>>> Execute(IEnumerable<InvoiceItemUpdateRequest> request, int invoiceId, int? userId = null)
        {
            List<InvoiceItem> items = new List<InvoiceItem>();

            foreach (var item in request)
            {
                Result<InvoiceItem> resultInvoiceItem = InvoiceItem.Create(item.Description, item.Amount, invoiceId, item.Id);

                if (resultInvoiceItem.IsFailure)
                    return Result<IEnumerable<InvoiceItem>>.Fail(resultInvoiceItem.Error);

                items.Add(resultInvoiceItem.GetValue());
            }

            using (var transaction = _transactionBuilder.OpenTransaction())
            {
                var resultUpdate = await _invoiceItemRepository.Update(items, x => x.InvoiceId == invoiceId);

                if (resultUpdate.IsFailure)
                {
                    transaction.Rollback();
                    return Result<IEnumerable<InvoiceItem>>.Fail(resultUpdate.Error);
                }

                transaction.Commit();

                return Result<IEnumerable<InvoiceItem>>.Ok(resultUpdate.GetValue());
            }
        }
    }
}

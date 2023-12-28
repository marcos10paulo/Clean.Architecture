using Clean.Architecture.Application.Extensions.Transaction;
using Clean.Architecture.Application.Interfaces.Data.Repositories;
using Clean.Architecture.Application.Interfaces.Transaction;
using Clean.Architecture.Application.Interfaces.UseCases.InvoiceCases.Commands;
using Clean.Architecture.Contracts.InvoiceContracts;
using Clean.Architecture.Domain.Entities.InvoiceEntity;
using Clean.Architecture.Domain.Entities.InvoiceItemEntity;
using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Application.UseCases.InvoiceCases.Commands
{
    public  class InvoiceUpdateCommand : IInvoiceUpdateCommand
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ITransactionBuilder _transactionBuilder;
        private readonly IInvoiceItemUpdateCommand _invoiceItemUpdateCommand;

        public InvoiceUpdateCommand(
            IInvoiceRepository invoiceRepository,
            ITransactionBuilder transactionBuilder,
            IInvoiceItemUpdateCommand invoiceItemUpdateCommand)
        {
            _invoiceRepository = invoiceRepository;
            _transactionBuilder = transactionBuilder;
            _invoiceItemUpdateCommand = invoiceItemUpdateCommand;
        }

        public async Task<Result<Invoice>> Execute(InvoiceUpdateRequest request, int? userId = null)
        {
            Result<Invoice> resultInvoice = Invoice.Create(request.Date);

            if (resultInvoice.IsFailure)
                return Result<Invoice>.Fail(resultInvoice.Error);

            using (var transaction = _transactionBuilder.OpenTransaction())
            {
                resultInvoice = await _invoiceRepository.Update(resultInvoice.GetValue());

                if (resultInvoice.IsFailure)
                {
                    transaction.Rollback();
                    return Result<Invoice>.Fail(resultInvoice.Error);
                }

                Invoice invoice = resultInvoice.GetValue();

                Result<IEnumerable<InvoiceItem>> invoiceItemsResult = await _invoiceItemUpdateCommand.Execute(request.Items, invoice.Id);

                if (invoiceItemsResult.IsFailure)
                {
                    transaction.Rollback();
                    return Result<Invoice>.Fail(resultInvoice.Error);
                }

                transaction.Commit();

                return Result<Invoice>.Ok(invoice);
            }

        }
    }
}

using Clean.Architecture.Application.Extensions.Transaction;
using Clean.Architecture.Application.Interfaces.Data.Repositories;
using Clean.Architecture.Application.Interfaces.Transaction;
using Clean.Architecture.Application.Interfaces.UseCases.InvoiceCases.Commands;
using Clean.Architecture.Contracts.InvoiceContracts;
using Clean.Architecture.Domain.Entities.InvoiceEntity;
using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Application.UseCases.InvoiceCases.Commands
{
    public  class InvoiceCreateCommand : IInvoiceCreateCommand
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ITransactionBuilder _transactionBuilder;
        private readonly IInvoiceItemCreateCommand _invoiceItemCreateCommand;

        public InvoiceCreateCommand(
            IInvoiceRepository invoiceRepository,
            ITransactionBuilder transactionBuilder,
            IInvoiceItemCreateCommand invoiceItemCreateCommand)
        {
            _invoiceRepository = invoiceRepository;
            _transactionBuilder = transactionBuilder;
            _invoiceItemCreateCommand = invoiceItemCreateCommand;
        }

        public async Task<Result<Invoice>> Execute(InvoiceCreateRequest request, int? userId = null)
        {
            Result<Invoice> resultInvoice = Invoice.Create(request.Date);

            if (resultInvoice.IsFailure)
                return Result<Invoice>.Fail(resultInvoice.Error);

            using (var transaction = _transactionBuilder.OpenTransaction())
            {
                resultInvoice = await _invoiceRepository.Create(resultInvoice.GetValue());

                if (resultInvoice.IsFailure)
                {
                    transaction.Rollback();
                    return Result<Invoice>.Fail(resultInvoice.Error);
                }

                Invoice invoice = resultInvoice.GetValue();

                foreach (var item in request.Items)
                {
                    var resultInvoiceItem = await _invoiceItemCreateCommand.Execute(item, invoice.Id);

                    if (resultInvoiceItem.IsFailure)
                    {
                        transaction.Rollback();
                        return Result<Invoice>.Fail(resultInvoice.Error);
                    }

                    invoice.AddItem(resultInvoiceItem.GetValue());
                }

                transaction.Commit();

                return Result<Invoice>.Ok(invoice);
            }

        }
    }
}

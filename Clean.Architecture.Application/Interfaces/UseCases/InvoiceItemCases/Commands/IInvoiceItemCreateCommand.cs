using Clean.Architecture.Contracts.InvoiceContracts;
using Clean.Architecture.Domain.Entities.InvoiceItemEntity;
using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Application.Interfaces.UseCases.InvoiceCases.Commands
{
    public interface IInvoiceItemCreateCommand 
    {
        Task<Result<InvoiceItem>> Execute(InvoiceItemCreateRequest request, int invoiceId, int? userId = null);
    }
}

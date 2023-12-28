using Clean.Architecture.Contracts.InvoiceContracts;
using Clean.Architecture.Domain.Entities.InvoiceItemEntity;
using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Application.Interfaces.UseCases.InvoiceCases.Commands
{
    public interface IInvoiceItemUpdateCommand 
    {
        Task<Result<InvoiceItem>> Execute(InvoiceItemUpdateRequest request, int? userId = null);
        Task<Result<IEnumerable<InvoiceItem>>> Execute(IEnumerable<InvoiceItemUpdateRequest> request, int invoiceId, int? userId = null);
    }
}

using Clean.Architecture.Contracts.InvoiceContracts;
using Clean.Architecture.Domain.Entities.InvoiceEntity;
using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Application.Interfaces.UseCases.InvoiceCases.Commands
{
    public interface IInvoiceCreateCommand 
    {
        Task<Result<Invoice>> Execute(InvoiceCreateRequest request, int? userId = null);
    }
}

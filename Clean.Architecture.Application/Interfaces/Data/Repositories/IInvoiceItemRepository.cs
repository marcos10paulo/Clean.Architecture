using Clean.Architecture.Application.Interfaces.Data.Repositories.Base;
using Clean.Architecture.Domain.Entities.InvoiceItemEntity;

namespace Clean.Architecture.Application.Interfaces.Data.Repositories
{
    public interface IInvoiceItemRepository :
        IBaseCreateRepository<InvoiceItem>,
        IBaseUpdateRepository<InvoiceItem>,
        IBaseListRepository<InvoiceItem>,
        IBaseGetRepository<InvoiceItem>,
        IBaseUpdateListRepository<InvoiceItem>
    {
    }
}

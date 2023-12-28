using Clean.Architecture.Application.Interfaces.Data.Repositories.Base;
using Clean.Architecture.Domain.Entities.InvoiceEntity;

namespace Clean.Architecture.Application.Interfaces.Data.Repositories
{
    public interface IInvoiceRepository :
        IBaseCreateRepository<Invoice>,
        IBaseUpdateRepository<Invoice>,
        IBaseListRepository<Invoice>,
        IBaseGetRepository<Invoice>
        
    {
    }
}

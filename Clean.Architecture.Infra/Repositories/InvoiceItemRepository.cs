using Clean.Architecture.Application.Interfaces.Data.Repositories;
using Clean.Architecture.Application.Interfaces.Data.Repositories.Generic;
using Clean.Architecture.Domain.Entities.InvoiceItemEntity;
using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Infra.Repositories
{
    public class InvoiceItemRepository: IInvoiceItemRepository 
    {
        private readonly Context _context;
        private readonly IGenericCreateRepository<InvoiceItem> _createRepository;
        private readonly IGenericUpdateRepository<InvoiceItem> _updateRepository;
        private readonly IGenericListRepository<InvoiceItem> _listRepository;
        private readonly IGenericGetRepository<InvoiceItem> _getRepository;
        private readonly IGenericListUpdateRepository<InvoiceItem> _listUpdateRepository;

        public InvoiceItemRepository(
            Context context,
            IGenericCreateRepository<InvoiceItem> createRepository,
            IGenericUpdateRepository<InvoiceItem> updateRepository,
            IGenericListRepository<InvoiceItem> listRepository,
            IGenericGetRepository<InvoiceItem> getRepository,
            IGenericListUpdateRepository<InvoiceItem> listUpdateRepository)
        {
            _context = context;
            _createRepository = createRepository;
            _updateRepository = updateRepository;
            _listRepository = listRepository;
            _getRepository = getRepository;
            _listUpdateRepository = listUpdateRepository;
        }

        public async Task<Result<InvoiceItem>> Create(InvoiceItem entity)
        {
            return await _createRepository.Create(_context, entity);
        }

        public async Task<Result<InvoiceItem>> Get(int id, bool? asNoTracking = true)
        {
            return await _getRepository.Get(_context, id, asNoTracking);
        }

        public async Task<Result<List<InvoiceItem>>> List()
        {
            return await _listRepository.List(_context);
        }

        public async Task<Result<InvoiceItem>> Update(InvoiceItem entity)
        {
            return await _updateRepository.Update(_context, entity);
        }

        public async Task<Result<IEnumerable<InvoiceItem>>> Update(IEnumerable<InvoiceItem> entities, Func<InvoiceItem, bool> filter)
        {
            return await _listUpdateRepository.Update(_context, entities, filter);
        }
    }
}

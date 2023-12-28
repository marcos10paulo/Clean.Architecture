using Clean.Architecture.Application.Interfaces.Data.Repositories;
using Clean.Architecture.Application.Interfaces.Data.Repositories.Generic;
using Clean.Architecture.Domain.Entities.InvoiceEntity;
using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Infra.Repositories
{
    public class InvoiceRepository: IInvoiceRepository
    {
        private readonly Context _context;
        private readonly IGenericCreateRepository<Invoice> _createRepository;
        private readonly IGenericUpdateRepository<Invoice> _updateRepository;
        private readonly IGenericListRepository<Invoice> _listRepository;
        private readonly IGenericGetRepository<Invoice> _getRepository;        

        public InvoiceRepository(
            Context context,
            IGenericCreateRepository<Invoice> createRepository,
            IGenericUpdateRepository<Invoice> updateRepository,
            IGenericListRepository<Invoice> listRepository,
            IGenericGetRepository<Invoice> getRepository)
        {
            _context = context;
            _createRepository = createRepository;
            _updateRepository = updateRepository;
            _listRepository = listRepository;
            _getRepository = getRepository;
        }

        public async Task<Result<Invoice>> Create(Invoice entity)
        {
            return await _createRepository.Create(_context, entity);
        }

        public async Task<Result<Invoice>> Get(int id, bool? asNoTracking = true)
        {
            return await _getRepository.Get(_context, id, asNoTracking);
        }

        public async Task<Result<List<Invoice>>> List()
        {
            return await _listRepository.List(_context);
        }

        public async Task<Result<Invoice>> Update(Invoice entity)
        {
            return await _updateRepository.Update(_context, entity);
        }
    }
}

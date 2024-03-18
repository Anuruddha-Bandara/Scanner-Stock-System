using ScannerStockSystem.Application.Interfaces.Repositories;
using ScannerStockSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.Persistence.Repositories
{
    public class ContactPersonRepository : IContactPersonRepository
    {
        private readonly IGenericRepository<ContactPerson> _genericRepository;
        public ContactPersonRepository(IGenericRepository<ContactPerson> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public Task<List<ContactPerson>> GetContactPersonByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

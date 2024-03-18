using ScannerStockSystem.Application.Interfaces.Repositories;
using ScannerStockSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public readonly IGenericRepository<Customer> _genericRepository;
        public CustomerRepository(IGenericRepository<Customer> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public Task<List<Customer>> GetCustomersByCountryAsync(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}

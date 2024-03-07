using Microsoft.EntityFrameworkCore;
using ScannerStockSystem.Application.Interfaces.Repositories;
using ScannerStockSystem.Domain.Entities;

namespace ScannerStockSystem.Persistence.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IGenericRepository<Country> _repository;

        public CountryRepository(IGenericRepository<Country> repository)
        {
            _repository = repository;
        }


        public async Task<List<Country>> GetCountriesByIdAsync(int id)
        {
            return await _repository.Entities.Where(x => x.Id == id).ToListAsync();
        }
    }
}

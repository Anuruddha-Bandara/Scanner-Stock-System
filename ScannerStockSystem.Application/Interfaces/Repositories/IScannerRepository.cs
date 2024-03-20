using ScannerStockSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.Application.Interfaces.Repositories
{
    public interface IScannerRepository
    {
        Task<List<Scanner>> GetScannersByIdAsync(int id);
    }
}

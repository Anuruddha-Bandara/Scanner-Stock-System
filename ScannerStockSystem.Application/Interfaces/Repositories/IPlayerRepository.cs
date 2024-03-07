using ScannerStockSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.Application.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        Task<List<Country>> GetPlayersByClubAsync(int clubId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.Application.DTOs
{
    public class AuthResponseDTO
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}

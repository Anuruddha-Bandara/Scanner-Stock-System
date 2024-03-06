using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScannerStockSystem.Domain.Common.Interfaces;
using ScannerStockSystem.Domain.Common;

namespace ScannerStockSystem.Domain.Entities
{
    public class Country : BaseAuditableEntity
    {      
        public string? CountryName { get; set; }
        public string? Description { get; set; }
    }
}

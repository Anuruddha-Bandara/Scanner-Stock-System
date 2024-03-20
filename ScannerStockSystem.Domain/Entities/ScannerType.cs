using ScannerStockSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.Domain.Entities
{
    public class ScannerType : BaseAuditableEntity
    {
        public string Type { get; set; }
        public string Description { get; set; }  
    }
}

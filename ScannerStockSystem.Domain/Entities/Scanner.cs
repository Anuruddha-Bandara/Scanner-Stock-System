using ScannerStockSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.Domain.Entities
{
    public class Scanner : BaseAuditableEntity
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string PartNo { get; set; }
        public string MaxPageSize { get; set; }
        public string Speed { get; set; }
        public string? SerialNo { get; set; }
        public ScannerType Type { get; set; }
    }
}

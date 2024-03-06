using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.Domain.Common.Interfaces
{
    public interface IAuditableEntity : IEntity
    {
        string? CreatedBy { get; set; }
        DateTime? CreatedDate { get; set; }
        string? UpdatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}

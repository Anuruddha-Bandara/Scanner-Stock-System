using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.Domain.Common.Interfaces
{
    internal interface IDomainEventDispatcher
    {
        Task DispatchAndClearEvents(IEnumerable<BaseEntity> entitiesWithEvents);
    }
}

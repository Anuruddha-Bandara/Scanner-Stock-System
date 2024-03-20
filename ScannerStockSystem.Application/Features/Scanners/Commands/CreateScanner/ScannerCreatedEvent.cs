using ScannerStockSystem.Domain.Common;
using ScannerStockSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.Application.Features.Scanners.Commands.CreateScanner
{
 

    public class ScannerCreatedEvent : BaseEvent
    {
        public Scanner Scanners { get; }

        public ScannerCreatedEvent(Scanner scanner)
        {
            Scanners = scanner;
        }
    }
}

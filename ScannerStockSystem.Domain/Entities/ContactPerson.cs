using ScannerStockSystem.Domain.Common;
using ScannerStockSystem.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.Domain.Entities
{
    public class ContactPerson : BaseAuditableEntity  //error IEntity //
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Land { get; set; }
        public string Email { get; set; }
        public Customer Customer { get; set; } 

    }
}

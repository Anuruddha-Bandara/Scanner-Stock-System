using ScannerStockSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.Domain.Entities
{
    public class Customer : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }       
        public string Address3 { get; set; }
        public Country Country { get; set; }
        //public IList<ContactPerson> ContactPersons { get; set; }
    }
}

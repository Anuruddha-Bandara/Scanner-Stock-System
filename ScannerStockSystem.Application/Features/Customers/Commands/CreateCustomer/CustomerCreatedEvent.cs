using ScannerStockSystem.Domain.Common;
using ScannerStockSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.Application.Features.Customers.Commands.CreateCustomer
{
    
    public class CustomerCreatedEvent : BaseEvent
    {
        public Customer Customer { get; }

        public CustomerCreatedEvent(Customer customer)
        {
            Customer = customer;
        }
    }
}

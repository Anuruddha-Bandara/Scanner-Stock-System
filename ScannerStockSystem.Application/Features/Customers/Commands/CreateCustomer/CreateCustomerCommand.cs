using AutoMapper;
using MediatR;
using ScannerStockSystem.Application.Common.Mappings;
using ScannerStockSystem.Application.Features.Countries.Commands.CreateCountry;
using ScannerStockSystem.Application.Interfaces.Repositories;
using ScannerStockSystem.Domain.Entities;
using ScannerStockSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.Application.Features.Customers.Commands.CreateCustomer
{
     
    public record CreateCustomerCommand : IRequest<Result<int>>, IMapFrom<Customer>
    {
        public string Name { get; set; }
        public int ShirtNo { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime? BirthDate { get; set; }
    }

    internal class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        { 
            Customer customer = new Customer(); 
            customer.Id = 1;
            customer.Name = "John Doe";
            customer.Address1 = "123 Main St";
            customer.Address2 = "Apt 101";
            customer.Address3 = "Some City";
            customer.CountryId = 1;

            var contactPerson = new ContactPerson
            {
                Name = "New Contact Person Name",
                CustomerId = customer.Id,
                Mobile = "0112545895",
                Land = "Passara",
                Email = "TestUser@Gmail.com",
                Customer = customer // Set the reference to the customer object
            };

            await _unitOfWork.Repository<Customer>().AddAsync(customer);
            await _unitOfWork.Repository<ContactPerson>().AddAsync(contactPerson);// if not extend BaseAuditableEntity
            customer.AddDomainEvent(new CustomerCreatedEvent(customer));

            await _unitOfWork.Save(cancellationToken);

            return await Result<int>.SuccessAsync(customer.Id, "Player Created.");
        }
    }
}

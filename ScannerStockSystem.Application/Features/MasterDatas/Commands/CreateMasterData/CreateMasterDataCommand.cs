using AutoMapper;
using MediatR;
using ScannerStockSystem.Application.Common.Mappings;
using ScannerStockSystem.Application.Features.Customers.Commands.CreateCustomer;
using ScannerStockSystem.Application.Interfaces.Repositories;
using ScannerStockSystem.Domain.Entities;
using ScannerStockSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.Application.Features.MasterDatas.Commands.CreateMasterData
{
    public class CreateMasterDataCommand : IRequest<Result<int>>, IMapFrom<MasterData>
    {
        public string Name { get; set; }
        public int ShirtNo { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime? BirthDate { get; set; } = DateTime.MinValue;
    }
    public class CreateMasterDataCommandHandler : IRequestHandler<CreateMasterDataCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateMasterDataCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<Result<int>> Handle(CreateMasterDataCommand request, CancellationToken cancellationToken)
        {


            var masterData = new MasterData
            {
                SanjePoNo = "ABC123",
                ManufactureInvoiceNo = "INV456",
                ManufactureSalesOrderNo = "SO789",
                ShipmentReceivedDate = DateTime.Now.AddDays(-10),
                UnitPrice = 100.50m,
                EndCustomerPoNo = "CDE456",
                DispatchDate = DateTime.Now.AddDays(-5),
                DeliveryNoteNo = "DN123",
                Dispatched = true,
                Customer = await _unitOfWork.Repository<Customer>().GetByIdAsync(1),
                Scanner = await _unitOfWork.Repository<Scanner>().GetByIdAsync(14)
            };
             //Customer = new Customer { Id=1, Name = "CustomerName", Address1 = "Addess1", Address2 = "Addess1", Address3 = "Addess1",Country= new Country { Name = "Nepal",Description = "New user" } },
             //Scanner = new Scanner { Speed="WD1223", Model = "ScannerModel",Make="West Us",PartNo="WS12",MaxPageSize ="10" ,SerialNo="125423",Type= new ScannerType {Type = "ST12E",Description="User Description" } 

            await _unitOfWork.Repository<MasterData>().AddAsync(masterData);
            masterData.AddDomainEvent(new MasterDataCreateEvent(masterData));

            await _unitOfWork.Save(cancellationToken);

            return await Result<int>.SuccessAsync(masterData.Id, "MasterData Created.");
        }
    }
}

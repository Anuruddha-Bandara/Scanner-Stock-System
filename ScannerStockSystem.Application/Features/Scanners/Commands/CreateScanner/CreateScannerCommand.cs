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

namespace ScannerStockSystem.Application.Features.Scanners.Commands.CreateScanner
{

    public record CreateScannerCommand : IRequest<Result<int>>, IMapFrom<Scanner>
    {
        public string Name { get; set; }
        public int ShirtNo { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime? BirthDate { get; set; }
    }

    internal class CreateScannerCommandHandler : IRequestHandler<CreateScannerCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateScannerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateScannerCommand command, CancellationToken cancellationToken)
        {


            var scannerType = new ScannerType
            {                
                Type = "Flatbed",
                Description = "A flatbed scanner type"
            };

            // Create a Scanner
            var scanner = new Scanner
            {
                Make = "ExampleMake",
                Model = "ExampleModel",
                PartNo = "12345",
                MaxPageSize = "A4",
                Speed = "50 pages per minute",
                Type = await _unitOfWork.Repository<ScannerType>().GetByIdAsync(1) // scannerType
        };

            await _unitOfWork.Repository<Scanner>().AddAsync(scanner);
            scanner.AddDomainEvent(new ScannerCreatedEvent(scanner));

            await _unitOfWork.Save(cancellationToken);

            return await Result<int>.SuccessAsync(scanner.Id, "Scanner Created.");
        }
    }
}

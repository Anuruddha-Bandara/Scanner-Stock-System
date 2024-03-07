using AutoMapper;
using MediatR;
using ScannerStockSystem.Application.Common.Mappings;
using ScannerStockSystem.Application.Interfaces.Repositories;
using ScannerStockSystem.Domain.Entities;
using ScannerStockSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.Application.Features.Countries.Commands.CreateCountry
{
     
    public record CreateCountryCommand : IRequest<Result<int>>, IMapFrom<Country>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    internal class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCountryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateCountryCommand command, CancellationToken cancellationToken)
        {
            var country = new Country()
            {
                Name = command.Name,
                Description = command.Description
            };

            await _unitOfWork.Repository<Country>().AddAsync(country);
            country.AddDomainEvent(new PlayerCreatedEvent(country));
            await _unitOfWork.Save(cancellationToken);
            return await Result<int>.SuccessAsync(country.Id, "Country Created.");
        }
    }
}

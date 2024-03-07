using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ScannerStockSystem.Application.Features.Countries.Queries.GetAllCountries;
using ScannerStockSystem.Application.Interfaces.Repositories;
using ScannerStockSystem.Domain.Entities;
using ScannerStockSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.Application.Features.Countries.Queries.GetAllCountries
{
     
    public record GetAllCountriesQuery : IRequest<Result<List<GetAllCountriesDto>>>;

    internal class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, Result<List<GetAllCountriesDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCountriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllCountriesDto>>> Handle(GetAllCountriesQuery query, CancellationToken cancellationToken)
        {
            var players = await _unitOfWork.Repository<Country>().Entities
                   .ProjectTo<GetAllCountriesDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);

            return await Result<List<GetAllCountriesDto>>.SuccessAsync(players);
        }
    }
}

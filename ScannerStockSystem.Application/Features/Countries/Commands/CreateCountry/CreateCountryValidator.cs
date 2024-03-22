using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.Application.Features.Countries.Commands.CreateCountry
{
   
   
    public sealed class CreateCountryValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).EmailAddress();
            RuleFor(x => x.Description).NotEmpty().MinimumLength(100).MaximumLength(50);
        }
    }
    }


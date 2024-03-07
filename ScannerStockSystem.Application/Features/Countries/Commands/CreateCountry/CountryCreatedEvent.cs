using ScannerStockSystem.Domain.Common;
using ScannerStockSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.Application.Features.Countries.Commands.CreateCountry
{
    public class PlayerCreatedEvent : BaseEvent
    {
        public Country Player { get; }

        public PlayerCreatedEvent(Country player)
        {
            Player = player;
        }
    }
}

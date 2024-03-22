using ScannerStockSystem.Domain.Common;
using ScannerStockSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.Application.Features.MasterDatas.Commands.CreateMasterData
{
    public class MasterDataCreateEvent : BaseEvent
    {
        MasterData _masterData;
        public MasterDataCreateEvent(MasterData masterData) => _masterData = masterData;
    }
}

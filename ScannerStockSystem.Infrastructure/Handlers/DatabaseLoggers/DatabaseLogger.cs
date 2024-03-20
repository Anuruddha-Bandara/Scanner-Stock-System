using MediatR;
using ScannerStockSystem.Application.Features.Scanners.Commands.CreateScanner;

namespace ScannerStockSystem.Infrastructure.Handlers.DatabaseLoggers
{


    public class DatabaseLogger : INotificationHandler<ScannerCreatedEvent>
    {
        public Task Handle(ScannerCreatedEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

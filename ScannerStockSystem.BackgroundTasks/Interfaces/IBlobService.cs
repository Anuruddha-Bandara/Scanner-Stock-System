using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.BackgroundTasks.Interfaces
{
    public interface IBlobService
    {
        public Task UploadBlobAsync(string containerName, string fileName, Stream content);
        public UploadInfo? Dequeue();
        public void Enqueue(string containerName, string fileName, Stream contentStream);
    }
}

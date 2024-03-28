using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using ScannerStockSystem.BackgroundTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.BackgroundTasks.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly Queue<UploadInfo> _uploadQueue = new Queue<UploadInfo>();
        public BlobService(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("AzureBlobStorage");
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public async Task UploadBlobAsync(string containerName, string fileName, Stream content)
        {
            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
                var blobClient = containerClient.GetBlobClient(fileName);
                await blobClient.UploadAsync(content);
            }catch (Exception ex)
            {

            }
        }
        
        

        public void Enqueue(string containerName, string fileName, Stream contentStream)
        {
            _uploadQueue.Enqueue(new UploadInfo { ContainerName = containerName, FileName = fileName, ContentStream = contentStream });
        }

        public UploadInfo? Dequeue()
        {
            //return _uploadQueue.Count > 0 ? _uploadQueue.Dequeue() : null;

            if (_uploadQueue.Count > 0)
            {
                return _uploadQueue.Dequeue();
            }
            else {

                return null;


            }

            
        }
    }
}

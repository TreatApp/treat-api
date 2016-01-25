using System.IO;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Treat.Model;

namespace Treat.Service
{
    public class FileService : IFileService
    {
        private const string EventsContainer = "events";

        private readonly ISettings _settings;

        public FileService(ISettings settings)
        {
            _settings = settings;
        }

        public void UploadEventImage(string fileName, byte[] content)
        {
            var storageAccount = CloudStorageAccount.Parse(_settings.StorageConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(EventsContainer);
            var blockBlob = container.GetBlockBlobReference(fileName);
            blockBlob.UploadFromByteArray(content, 0, content.Length);
        }
    }
}
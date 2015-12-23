using System.IO;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;

namespace Treat.Service
{
    public class FileService : IFileService
    {
        private static readonly string EventsContainer = "events";

        public void UploadEventImage(string fileName, byte[] content)
        {
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(EventsContainer);
            var blockBlob = container.GetBlockBlobReference(fileName);
            blockBlob.UploadFromByteArray(content, 0, content.Length);
        }
    }
}
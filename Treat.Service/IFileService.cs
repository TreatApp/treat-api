using System.IO;

namespace Treat.Service
{
    public interface IFileService
    {
        void UploadEventImage(string fileName, byte[] content);
    }
}
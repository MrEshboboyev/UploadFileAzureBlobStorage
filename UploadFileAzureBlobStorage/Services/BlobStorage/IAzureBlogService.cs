using UploadFileAzureBlobStorage.Models;

namespace UploadFileAzureBlobStorage.Services.BlobStorage
{
    public interface IAzureBlogService
    {
        Task<AzureBlobResponse> UploadFileAsync(string blobContainer, 
            string directoryName, string fileName, string fileStream);
    }
}

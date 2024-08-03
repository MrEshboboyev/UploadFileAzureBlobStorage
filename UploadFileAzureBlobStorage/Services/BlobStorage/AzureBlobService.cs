using Azure.Storage.Blobs;
using UploadFileAzureBlobStorage.Models;

namespace UploadFileAzureBlobStorage.Services.BlobStorage
{
    public class AzureBlobService : IAzureBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public AzureBlobService(BlobServiceClient blobServiceClient) 
        {
            _blobServiceClient = blobServiceClient;
        }

        public Task<AzureBlobResponse> UploadFileAsync(string blobContainer, string directoryName, string fileName, string fileStream)
        {
            throw new NotImplementedException();
        }
    }
}

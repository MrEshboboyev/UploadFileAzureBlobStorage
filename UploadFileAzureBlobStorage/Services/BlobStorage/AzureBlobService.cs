using Azure;
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

        public async Task<AzureBlobResponse> UploadFileAsync(string blobContainer, 
            string directoryName, string fileName, string fileStream)
        {
            var blobResponse = new AzureBlobResponse();

            try
            {
                // create blob container
                var container = _blobServiceClient.GetBlobContainerClient(blobContainer);
                await container.CreateIfNotExistsAsync();

                // folder1/folder2/fileName.pdf
                var blob = container.GetBlobClient($"{directoryName}/{fileName}");
                var blobResult = await blob.UploadAsync(fileStream);

                blobResponse = new AzureBlobResponse
                {
                    BlobUri = blob.Uri,
                    FileName = blob.Name,
                    StatusCode = blobResult.GetRawResponse().Status,
                    ReasonPhrase = blobResult.GetRawResponse().ReasonPhrase
                };
            }
            catch (RequestFailedException rfex)
            {
                blobResponse.IsError = true;
                blobResponse.StatusCode = rfex.Status;
                blobResponse.ErrorMessage = rfex.Message;
            }
            catch (Exception ex)  
            {
                blobResponse.IsError = true;
                blobResponse.StatusCode = 500;
                blobResponse.ErrorMessage = ex.Message;
            }

            return blobResponse;
        }
    }
}

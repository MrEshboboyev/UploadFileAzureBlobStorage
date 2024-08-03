using Azure.Core.Extensions;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Azure;

namespace UploadFileAzureBlobStorage
{
    public static class AzureClientFactoryBuilderExtensions
    {
        public static IAzureClientBuilder<BlobServiceClient, BlobClientOptions> 
            AddBlobServiceClient(this AzureClientFactoryBuilder builder, 
                string serviceUriConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriConnectionString, 
                UriKind.Absolute, out Uri? serviceUri))
            {
                return builder.AddBlobServiceClient(serviceUri);
            }
            else
            {
                return builder.AddBlobServiceClient(serviceUriConnectionString);
            }
        }
    }
}

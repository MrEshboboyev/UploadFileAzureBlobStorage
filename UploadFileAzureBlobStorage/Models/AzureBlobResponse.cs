namespace UploadFileAzureBlobStorage.Models
{
    public class AzureBlobResponse
    {
        public int StatusCode { get; set; }
        public string ReasonPhrase { get; set; }
        public Uri BlobUri { get; set; }
        public bool IsError { get; set; }
        public string FileName { get; set; }
        public byte[]? FileBytes { get; set; }
        public string ErrorMessage { get; set; }
    }
}

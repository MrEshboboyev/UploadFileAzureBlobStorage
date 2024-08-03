using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadFileAzureBlobStorage.Services.BlobStorage;

namespace UploadFileAzureBlobStorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobController : ControllerBase
    {
        private readonly IAzureBlobService _azureBlobService;

        public BlobController(IAzureBlobService azureBlobService)
        {
            _azureBlobService = azureBlobService;
        }
    }
}

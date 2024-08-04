using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadFileAzureBlobStorage.Models;
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

        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFile([FromForm] FileUploadModel model)
        {
            // checking file is valid
            if (model.File == null ||  model.File.Length == 0)
            {
                return BadRequest("Invalid File!");
            }

            var fileStream = model.File.OpenReadStream();

            var result = await _azureBlobService.UploadFileAsync("blobupload", "mynewfolder",
                model.File.FileName, fileStream);

            if(result.IsError)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}

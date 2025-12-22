using MachineAssetManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace MachineAssetManagement.Controllers
{
    [ApiController]
    [Route("api/upload")]
    public class UploadController : ControllerBase
    {
        private readonly UploadService _uploadService;

        public UploadController(UploadService uploadService)
        {
            _uploadService = uploadService;
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file, bool replace = true)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is required");

            var tempPath = Path.GetTempFileName();
            var extension = Path.GetExtension(file.FileName);

            var uploadPath = Path.ChangeExtension(tempPath, extension);

            using (var stream = System.IO.File.Create(uploadPath))
            {
                file.CopyTo(stream);
            }

            _uploadService.SaveMatrix(uploadPath, replace);

            return Ok("Matrix updated successfully");
        }
    }
}

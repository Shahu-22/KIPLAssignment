using MachineAssetManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace MachineAssetManagement.Controllers
{
    [ApiController]
    [Route("api/upload")]
    public class UploadController : ControllerBase
    {
        private readonly IDataLoader _dataLoader;

        public UploadController(IDataLoader dataLoader)
        {
            _dataLoader = dataLoader;
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file,  bool replace = true)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { message = "File is required" });

            var tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + Path.GetExtension(file.FileName));

            try
            {
                using (var stream = System.IO.File.Create(tempPath))
                {
                    file.CopyTo(stream);
                }

                _dataLoader.SaveMatrix(tempPath, replace);

                return Ok(new { message = "Matrix updated successfully" });
            }
            catch (NotSupportedException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (FormatException ex)
            {
                return BadRequest(new { message = $"File format error: {ex.Message}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Server error: {ex.Message}" });
            }
            finally
            {
                if (System.IO.File.Exists(tempPath))
                    System.IO.File.Delete(tempPath);
            }
        }
    }
}

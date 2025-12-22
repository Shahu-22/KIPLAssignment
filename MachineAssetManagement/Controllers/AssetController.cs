using MachineAssetManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace MachineAssetManagement.Controllers
{
    [ApiController]
    [Route("api/assets")]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;
        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }
        [HttpGet("{name}/machines")]
        public IActionResult GetMachines(string name)
        {
            return Ok(_assetService.GetMachinesByAsset(name));
        }
    }
}

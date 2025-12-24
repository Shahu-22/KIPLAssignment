using MachineAssetManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace MachineAssetManagement.Controllers
{
    [ApiController]
    [Route("api/machines")]
    public class MachineController : ControllerBase
    {
        private readonly IMachineService _machineService;
        public MachineController(IMachineService machineService)
        {
            _machineService = machineService;
        }
        [HttpGet("{name}/assets")]
        public ActionResult GetAssets(string name)
        {
            return Ok(_machineService.GetAssetsByMachine(name));
        }
        [HttpGet("all-machines")]
        public ActionResult GetMachines()
        {
            return Ok(_machineService.GetAllMachines());
        }
        [HttpGet("latest-series")]
        public IActionResult GetMachineWithLatestAsset()
        {
            return Ok(_machineService.GetMachineWithLatestAsset()) ;
        }

        [HttpGet("{name}/machine")]
        public IActionResult GetMachines(string name)
        {
            return Ok(_machineService.GetMachinesByAsset(name));
        }
    }
}

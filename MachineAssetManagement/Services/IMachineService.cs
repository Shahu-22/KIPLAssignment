using MachineAssetManagement.Models;

namespace MachineAssetManagement.Services
{
    public interface IMachineService
    {
        List<string> GetAssetsByMachine(string machineName);
        List<string> GetMachineWithLatestAsset();
        List<Machines> GetAllMachines();
    }
}

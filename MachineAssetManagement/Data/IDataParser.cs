using MachineAssetManagement.Models;
using System.Reflection.PortableExecutable;

namespace MachineAssetManagement.Data
{
    public interface IDataParser
    {
        List<Machines> ParseMachines(string filePath);
        List<Asset> ParseAssets(string filePath);
    }
}


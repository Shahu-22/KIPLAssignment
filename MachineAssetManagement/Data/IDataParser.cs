using MachineAssetManagement.Models;
using System.Reflection.PortableExecutable;

namespace MachineAssetManagement.Data
{
    public interface IDataParser
    {
        bool canHandle(string ext);
        List<Machines> ParseMachines(string filePath);
    }
}


using MachineAssetManagement.Data;
using MachineAssetManagement.Models;
using System.Reflection.PortableExecutable;

namespace MachineAssetManagement.Data
{
   public class Repository
{
    private readonly IDataParser _parser;

    public Repository(IDataParser parser)
    {
        _parser = parser;
    }

    public List<Machines> GetMachines(string filePath) => _parser.ParseMachines(filePath);
    public List<Asset> GetAssets(string filePath) => _parser.ParseAssets(filePath);
}

}

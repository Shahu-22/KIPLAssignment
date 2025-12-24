using MachineAssetManagement.Data;
using MachineAssetManagement.Models;
using MachineAssetManagement.Services;

public class MachineService : IMachineService
{
    private readonly ParserFactory _parserFactory;
    private readonly string _filePath;

    public MachineService(ParserFactory parserFactory, string filePath)
    {
        _parserFactory = parserFactory;
        _filePath = filePath;
    }

    public List<Machines> GetAllMachines()
    {
        var parser = _parserFactory.GetParser(_filePath);
        return parser.ParseMachines(_filePath);
    }

    public List<string> GetAssetsByMachine(string machineName)
    {
        var record = GetAllMachines();
        
        return record.Where(m => m.Name.Equals(machineName, StringComparison.OrdinalIgnoreCase))
        .SelectMany(m => m.Assets.Keys)
        .Distinct()
        .ToList();

    }

    public List<string> GetMachineWithLatestAsset()
    {
       
        var record = GetAllMachines();
        var latestAssetSeries = record
                                .SelectMany(m => m.Assets)         
                                .GroupBy(a => a.Key)                
                                .ToDictionary(
                                g => g.Key,
                                g => g.Max(x => x.Value)        
                                );
        var machinesUsingLatestAssets = record
                                        .Where(m =>
                                         m.Assets.All(asset =>
                                         latestAssetSeries.TryGetValue(asset.Key, out var latest)
                                         && asset.Value == latest
                                         )
                                         )
                                        .Select(m => m.Name)
                                        .Distinct()
                                        .ToList();

    return machinesUsingLatestAssets;

        
    }

    public List<string> GetMachinesByAsset(string assetName)
    {
        
        var record = GetAllMachines();

        return record
        .Where(m => m.Assets.Keys
        .Any(k => string.Equals(k, assetName, StringComparison.OrdinalIgnoreCase)))
        .Select(m => m.Name)
        .Distinct()
        .ToList();

    }
}

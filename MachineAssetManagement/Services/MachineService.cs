using MachineAssetManagement.Data;
using MachineAssetManagement.Models;
using MachineAssetManagement.Services;

public class MachineService : IMachineService
{
    private readonly IRepository _repo;
    public MachineService(IRepository repo)
    {
        _repo = repo;
    }

    public List<Machines> GetAllMachines()
    {
        return _repo.LoadMachines();
    }
    public List<string> GetAssetsByMachine(string machineName)
    {
        return _repo.LoadMachines()
              .Where(m => m.Name.Equals(machineName, StringComparison.OrdinalIgnoreCase))
              .SelectMany(m => m.Assets.Keys)
              .Distinct()
              .ToList();

    }

    public List<string> GetMachineWithLatestAsset()
    {
        var latestAssetSeries = _repo.LoadMachines()
                                .SelectMany(m => m.Assets)         
                                .GroupBy(a => a.Key)                
                                .ToDictionary(
                                         g => g.Key,
                                         g => g.Max(x => x.Value));
        var machinesUsingLatestAssets = _repo.LoadMachines()
                                  .Where
                                        (m =>m.Assets.All(asset =>
                                        latestAssetSeries
                                        .TryGetValue(asset.Key, out var latest)
                                        && asset.Value == latest))
                                  .Select(m => m.Name)
                                  .ToList();

    return machinesUsingLatestAssets;

        
    }

    public List<string> GetMachinesByAsset(string assetName)
    {
        return _repo.LoadMachines()
        .Where(m => m.Assets.Keys
        .Any(k => string.Equals(k, assetName, StringComparison.OrdinalIgnoreCase)))
        .Select(m => m.Name)
        .Distinct()
        .ToList();

    }
}

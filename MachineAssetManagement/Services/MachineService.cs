using MachineAssetManagement.Data;

namespace MachineAssetManagement.Services
{
    public class MachineService : IMachineService
    {
        private readonly Repository _repository;
        private readonly string _filePath;

        public MachineService(Repository repository, string filePath)
        {
            _repository = repository;
            _filePath = filePath;
        }

        public List<string> GetAssetsByMachine(string machineName)
        {
            var machine = _repository.GetMachines(_filePath)
                .FirstOrDefault(m => m.Name == machineName);
            return machine?.GetAssetNames() ?? new List<string>();
        }

        public List<string> GetMachineWithLatestAsset()
        {
            var assets = _repository.GetAssets(_filePath);
            var latestSeries = assets.ToDictionary(a => a.Name, a => a.GetLatestAsset());

            return _repository.GetMachines(_filePath)
                .Where(m => m.IsUsingLatestSeries(latestSeries))
                .Select(m => m.Name)
                .ToList();
        }
    }

}

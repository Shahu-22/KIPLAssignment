using MachineAssetManagement.Data;

namespace MachineAssetManagement.Services
{
    public class AssetService:IAssetService
    {
        private readonly Repository _repository;
        private readonly string _filePath;
        public AssetService(Repository repository, string filePath)
        {
            _repository = repository;
            _filePath = filePath;
        }
        public List<string> GetMachinesByAsset( string assetName)
        {
            return _repository.GetMachines(_filePath).
                Where(m=>m.AssetUsage.Any(a=>a.Asset.Name == assetName))
                .Select(m=>m.Name).ToList();
        }
    }
}

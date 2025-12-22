namespace MachineAssetManagement.Services
{
    public interface IAssetService
    {
        List<string> GetMachinesByAsset(string assetName);
    }
}

namespace MachineAssetManagement.Services
{
    public interface IDataLoader
    {
        public void SaveMatrix(string uploadedFilePath, bool replace = true);
    }
}

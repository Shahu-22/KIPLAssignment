namespace MachineAssetManagement.Services
{
    public interface IRepository
    {
        public List<Machines> LoadMachines();
        public List<Machines> LoadMachines(string uploadFilePath);
       
    }
}

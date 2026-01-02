namespace MachineAssetManagement.Services
{
    public class FileDataLoader:IDataLoader
    {
        private readonly string _filePath;
        private readonly IRepository _repo;
        public FileDataLoader(string filePath, IRepository repo)
        {
            _filePath = filePath;
            _repo = repo;
        }
        public void SaveMatrix(string uploadedFilePath, bool replace = true)
        {
            if (string.IsNullOrWhiteSpace(uploadedFilePath))
                throw new ArgumentException("Invalid file path");

            var machines = _repo.LoadMachines(uploadedFilePath);

            var lines = new List<string>();
            foreach (var machine in machines)
            {
                foreach (var asset in machine.Assets)
                {
                    lines.Add($"{machine.Name},{asset.Key},{asset.Value}");
                }
            }
            if (replace)
            {
                File.WriteAllLines(_filePath, lines);
                return;
            }
            File.AppendAllLines(_filePath, lines);

        }

    }
}

using MachineAssetManagement.Data;
using MachineAssetManagement.Models;

namespace MachineAssetManagement.Services
{
    public class UploadService
    {
        private readonly MatrixFileService _fileService;

        public UploadService(MatrixFileService fileService)
        {
            _fileService = fileService;
        }

        public void SaveMatrix(string uploadedFilePath, bool replace = true)
        {
            if (string.IsNullOrWhiteSpace(uploadedFilePath))
                throw new ArgumentException("Invalid file path");

            // 🔹 Get parser based on file extension
            var parser = ParserFactory.GetParser(uploadedFilePath);

            // 🔹 Parse uploaded file
            var machines = parser.ParseMachines(uploadedFilePath);

            // 🔹 Convert parsed data to matrix.txt format
            var lines = new List<string>();

            foreach (var machine in machines)
            {
                foreach (var usage in machine.AssetUsage)
                {
                    lines.Add(
                        $"{machine.Name},{usage.Asset.Name},{usage.Series}"
                    );
                }
            }

            // 🔹 Save to matrix.txt
            if (replace)
                _fileService.ReplaceFile(lines);
            else
                _fileService.AppendFile(lines);
        }
    }
}

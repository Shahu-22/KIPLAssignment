using MachineAssetManagement.Data;
using MachineAssetManagement.Models;

namespace MachineAssetManagement.Services
{
    public class UploadService
    {
        private readonly MatrixFileService _fileService;
        private readonly IEnumerable<IDataParser> _parsers;

        public UploadService(MatrixFileService fileService, IEnumerable<IDataParser> parsers)
        {
            _fileService = fileService;
            _parsers = parsers;
        }

        public void SaveMatrix(string uploadedFilePath, bool replace = true)
        {
            if (string.IsNullOrWhiteSpace(uploadedFilePath))
                throw new ArgumentException("Invalid file path");

            // Get parser dynamically based on file extension
            var extension = Path.GetExtension(uploadedFilePath).ToLowerInvariant();
            var parser = _parsers.FirstOrDefault(p => p.canHandle(extension)) ??
           throw new NotSupportedException($"No parser registered");

            // Parse uploaded file
            var machines =  parser.ParseMachines(uploadedFilePath);

            // Convert parsed data to matrix.txt format
            var lines = new List<string>();
            foreach (var machine in machines)
            {
                foreach (var asset in machine.Assets)
                {
                    lines.Add($"{machine.Name},{asset.Key},{asset.Value}");
                }
            }

            // Save to Matrix.txt using MatrixFileService
            if (replace)
              _fileService.ReplaceFile(lines);
            else
                _fileService.AppendFile(lines);
        }
    }
}

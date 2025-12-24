using MachineAssetManagement.Data;
using MachineAssetManagement.Models;

namespace MachineAssetManagement.Services
{
    public class UploadService
    {
        private readonly MatrixFileService _fileService;
        private readonly ParserFactory _parserFactory;

        public UploadService(MatrixFileService fileService, ParserFactory parserFactory)
        {
            _fileService = fileService;
            _parserFactory = parserFactory;
        }

        public void SaveMatrix(string uploadedFilePath, bool replace = true)
        {
            if (string.IsNullOrWhiteSpace(uploadedFilePath))
                throw new ArgumentException("Invalid file path");

            // Get parser dynamically based on file extension
            var parser = _parserFactory.GetParser(uploadedFilePath);

            // Parse uploaded file
            var machines = parser.ParseMachines(uploadedFilePath);

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

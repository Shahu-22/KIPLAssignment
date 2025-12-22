using System.IO;

namespace MachineAssetManagement.Data
{
    public static class ParserFactory
    {
        public static IDataParser GetParser(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Invalid file path");

            var extension = Path.GetExtension(filePath).ToLowerInvariant();

            return extension switch
            {
                ".txt" => new TxtParser(),
                ".csv" => new TxtParser(),   // CSV handled by same logic
                ".json" => new JsonParser(),
                _ => throw new NotSupportedException(
                        $"Unsupported file type: {extension}")
            };
        }
    }
}

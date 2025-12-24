namespace MachineAssetManagement.Data
{
    public class ParserFactory
    {
        private readonly TxtParser _txtParser;
        private readonly JsonParser _jsonParser;

        public  ParserFactory(TxtParser txtParser, JsonParser jsonParser)
        {
            _txtParser = txtParser;
            _jsonParser = jsonParser;
        }

        public IDataParser GetParser(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLowerInvariant();

            return extension switch
            {
                ".txt" or ".csv" => _txtParser,
                ".json" => _jsonParser,
                _ => throw new NotSupportedException(
                    $"Unsupported file type: {extension}")
            };
        }
    }
}

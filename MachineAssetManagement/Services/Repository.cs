using MachineAssetManagement.Data;
using static System.Net.Mime.MediaTypeNames;

namespace MachineAssetManagement.Services
{
    public class Repository
    {
        private readonly IEnumerable<IDataParser> _parsers;
        private readonly string _filePath;

        private List<Machines>? _machines;

        public Repository(IEnumerable<IDataParser> parsers, string filePath)
        {
            _parsers = parsers;
            _filePath = filePath;
        }

        public List<Machines> LoadMachines()
        {
            //if (_machines != null)
            //    return _machines;

            if (string.IsNullOrWhiteSpace(_filePath))
                throw new ArgumentException("File path is empty");

            if (!File.Exists(_filePath))
                return new List<Machines>();

            var ext = Path.GetExtension(_filePath);

            var parser = _parsers.FirstOrDefault(p => p.canHandle(ext))
                ?? throw new NotSupportedException($"No parser for {ext}");

            _machines = parser.ParseMachines(_filePath); 
            return _machines;
        }

     //public void InvalidateCache()
     //   {
     //       _machines = null;
     //   }
    }
}

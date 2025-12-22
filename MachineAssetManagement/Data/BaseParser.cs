using MachineAssetManagement.Models;
using System.Reflection.PortableExecutable;

namespace MachineAssetManagement.Data
{
    public abstract class BaseParser:IDataParser
    {
        protected void ValidateFile(string filePath)
        {
            if(string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path is empty...!");
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File nit Found", filePath);
        }
        protected bool IsValidSeries(string series)
        {
            return series.StartsWith("S") &&
                int.TryParse(series.Substring(1), out _);
        }
        public abstract List<Machines> ParseMachines(string filePath);
        public abstract List<Asset> ParseAssets(string filePath);
    }
}


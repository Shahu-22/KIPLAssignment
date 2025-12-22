using MachineAssetManagement.Models;

namespace MachineAssetManagement.Data
{
    public class TxtParser : BaseParser
    {
        public override List<Machines> ParseMachines(string filePath)
        {
            ValidateFile(filePath);

            var machineDict = new Dictionary<string, Machines>();
            var assetDict = new Dictionary<string, Asset>();

            int lineNo = 0;

            foreach (var line in File.ReadLines(filePath))
            {
                lineNo++;

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split(',');
                if (parts.Length != 3)
                    throw new FormatException($"Invalid format at line {lineNo}");

                var machineName = parts[0].Trim();
                var assetName = parts[1].Trim();
                var series = parts[2].Trim();

                if (!IsValidSeries(series))
                    throw new FormatException($"Invalid series '{series}' at line {lineNo}");

                if (!assetDict.ContainsKey(assetName))
                    assetDict[assetName] = new Asset { Name = assetName };

                assetDict[assetName].AddSeries(series);

                if (!machineDict.ContainsKey(machineName))
                    machineDict[machineName] = new Machines { Name = machineName };

                machineDict[machineName]
                    .AddAssetUsage(new AssetUsage(assetDict[assetName], series));
            }

            return machineDict.Values.ToList();
        }

        public override List<Asset> ParseAssets(string filePath)
        {
           ValidateFile(filePath);
            var assetDict = new Dictionary<string, Asset>();
            int lineNo = 0; 
            foreach (var line in File.ReadLines(filePath))
            {
                lineNo++;
                if (string.IsNullOrWhiteSpace(line))
                    continue;


                var parts = line.Split(",");
                if (parts.Length!=3)
                    throw new FormatException($"Invalid format at line {lineNo}");
                var assetName = parts[1].Trim();
                var series = parts[2].Trim();
                if (!IsValidSeries(series)) 
                    throw new FormatException($"Invalid Series {series} at line {lineNo}");
                if (!assetDict.ContainsKey(assetName))
                    assetDict[assetName] = new Asset { Name = assetName };
                assetDict[assetName].AddSeries(series);
            }
            return assetDict.Values.ToList();
        }
    }
}

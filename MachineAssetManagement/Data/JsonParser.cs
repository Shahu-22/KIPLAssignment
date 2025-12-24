using System.Text.Json;
using MachineAssetManagement.Models;

namespace MachineAssetManagement.Data
{
    public class JsonParser : BaseParser
    {
        private class JsonRecord
        {
            public string Machine { get; set; } = "";
            public string Asset { get; set; } = "";
            public string Series { get; set; } = "";
        }

        public override List<Machines> ParseMachines(string filePath)
        {
            ValidateFile(filePath);

            var json = File.ReadAllText(filePath);
            var records = JsonSerializer.Deserialize<List<JsonRecord>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (records == null || records.Count == 0)
                throw new FormatException("Invalid or empty JSON");

            var machineDict = new Dictionary<string, Machines>();
            var assetDict = new Dictionary<string, Asset>(); // Optional, if you need asset series globally

            foreach (var rec in records)
            {
                if (!IsValidSeries(rec.Series))
                    throw new FormatException($"Invalid series '{rec.Series}'");
                if (!machineDict.ContainsKey(rec.Machine))
                    machineDict[rec.Machine] = new Machines { Name = rec.Machine };

                // Add directly to dictionary in Machines
                machineDict[rec.Machine].AddAsset(rec.Asset, rec.Series);
            }

            return machineDict.Values.ToList();
        }

        public override List<Asset> ParseAssets(string filePath)
        {
            ValidateFile(filePath);

            var machines = ParseMachines(filePath);
            var assetDict = new Dictionary<string, Asset>();

            foreach (var machine in machines)
            {
                foreach (var kvp in machine.Assets)
                {
                    var assetName = kvp.Key;
                    var series = kvp.Value;

                    if (!assetDict.ContainsKey(assetName))
                        assetDict[assetName] = new Asset { Name = assetName };

                    assetDict[assetName].AddSeries(series);
                }
            }

            return assetDict.Values.ToList();
        }
    }
}

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
            var assetDict = new Dictionary<string, Asset>();

            foreach (var rec in records)
            {
                if (!IsValidSeries(rec.Series))
                    throw new FormatException($"Invalid series '{rec.Series}'");

                if (!assetDict.ContainsKey(rec.Asset))
                    assetDict[rec.Asset] = new Asset { Name = rec.Asset };

                assetDict[rec.Asset].AddSeries(rec.Series);

                if (!machineDict.ContainsKey(rec.Machine))
                    machineDict[rec.Machine] = new Machines { Name = rec.Machine };

                machineDict[rec.Machine].AddAssetUsage(
                    new AssetUsage(assetDict[rec.Asset], rec.Series)
                );
            }

            return machineDict.Values.ToList();
        }

        public override List<Asset> ParseAssets(string filePath)
        {
            var machines = ParseMachines(filePath);

            return machines
                .SelectMany(m => m.AssetUsage)
                .GroupBy(u => u.Asset.Name)
                .Select(g =>
                {
                    var asset = new Asset { Name = g.Key };
                    foreach (var u in g)
                        asset.AddSeries(u.Series);
                    return asset;
                })
                .ToList();
        }
    }
}

using System.Text.Json;
using MachineAssetManagement.Models;

namespace MachineAssetManagement.Data
{
    public class JsonParser : IDataParser
    {
        private class JsonRecord
        {
            public string Machine { get; set; } = "";
            public string Asset { get; set; } = "";
            public string Series { get; set; } = "";
        }

        public bool canHandle(string ext) => ext == ".json";
        

        public   List<Machines> ParseMachines(string filePath)
        {
            var json = File.ReadAllText(filePath);
            var records = JsonSerializer.Deserialize<List<JsonRecord>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (records == null || records.Count == 0)
                throw new FormatException("Invalid or empty JSON");

            var machineDict = new Dictionary<string, Machines>();
            foreach (var rec in records)
            {
                
                if (!machineDict.ContainsKey(rec.Machine))
                    machineDict[rec.Machine] = new Machines { Name = rec.Machine };

        
                machineDict[rec.Machine].AddAsset(rec.Asset, rec.Series);
            }

            return machineDict.Values.ToList();
        }
    }
}

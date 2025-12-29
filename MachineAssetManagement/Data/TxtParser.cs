using MachineAssetManagement.Models;
using System.Xml.Linq;

namespace MachineAssetManagement.Data
{
    public class TxtParser : IDataParser
    {
        public bool canHandle(string ext) => ext == ".txt" || ext ==".csv";
        public  List<Machines> ParseMachines(string filePath)
        {
           

            var machineDict = new Dictionary<string, Machines>();
            int lineNo = 0;

            foreach (var line in File.ReadLines(filePath))
            {
                lineNo++;
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(',');
                if (parts.Length != 3) continue;
                var machineName = parts[0].Trim();
                var assetName = parts[1].Trim();
                var series = parts[2].Trim();

                
                if (!machineDict.ContainsKey(machineName))
                    machineDict[machineName] = new Machines { Name = machineName};

                machineDict[machineName].AddAsset(assetName, series);

                
            }

            return machineDict.Values.ToList();
        }    
    }
}

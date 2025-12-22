namespace MachineAssetManagement.Models
{
    public class Machines
    {
      public string Name { get; set; }
        public List<AssetUsage> AssetUsage { get; set; } =new List<AssetUsage>();

        public void AddAssetUsage(AssetUsage usage)
        {
            AssetUsage.Add(usage);
        }
        //stroes assets and their series call AssetUsage constructor
        public List<string> GetAssetNames()
        {
            return AssetUsage.Select(a=>a.Asset.Name).Distinct().ToList();
        }
        //check is asset uses latest series or not
        public bool IsUsingLatestSeries(Dictionary<string, string> latestSeriesPerAsset)
        {
            foreach (var usage in AssetUsage)
            {
                if (!latestSeriesPerAsset.ContainsKey(usage.Asset.Name))
                    return false;
                if (usage.Series != latestSeriesPerAsset[usage.Asset.Name])
                    return false;
            }
            return true;
        }
    }

}

namespace MachineAssetManagement.Models
{

        public class AssetUsage
        {
           public Asset Asset { get; set; } 
        public string Series { get; set; } 
        public AssetUsage(Asset asset, string series)
        {
            Asset = asset;
            Series = series;
        }
    }

}


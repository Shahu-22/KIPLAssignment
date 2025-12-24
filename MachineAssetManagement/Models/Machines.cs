public class Machines
{
    public string Name { get; set; } = "";

    // AssetName → Series
    public Dictionary<string, string> Assets { get; set; } = new();

    public void AddAsset(string assetName, string series)
    {
        Assets[assetName] = series;
    }

    public List<string> GetAssetNames()
    {
        return Assets.Keys.ToList();
    }

    public bool IsUsingLatestSeries(Dictionary<string, string> latestAssetSeries)
    {
        foreach (var asset in Assets)
        {
            if (latestAssetSeries.TryGetValue(asset.Key, out var latest))
            {
                if (asset.Value != latest)
                    return false;
            }
        }
        return true;
    }
}

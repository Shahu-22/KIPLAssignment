public class Machines
{
    public string Name { get; set; } = "";

    // AssetName → Series
    public Dictionary<string, string> Assets { get; set; } = new();

    public void AddAsset(string assetName, string series)
    {
        Assets[assetName] = series;
    }

    

}

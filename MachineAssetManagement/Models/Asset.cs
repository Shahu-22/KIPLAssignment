namespace MachineAssetManagement.Models
{
    public class Asset
    {
      public string Name { get; set; }
      public List<string> SeriesNumbers { get; set; }=new List<string>();

        public void AddSeries(string series)
        {   
            if(!SeriesNumbers.Contains(series))
                SeriesNumbers.Add(series); 
        }
        public string GetLatestAsset()
        {
            return SeriesNumbers.OrderByDescending(s => int.Parse(s.Substring(1))).FirstOrDefault();
        }
    }

}

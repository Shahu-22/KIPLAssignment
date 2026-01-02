using MachineAssetManagement.Data;
using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Driver;
namespace MachineAssetManagement.Services
{
    public class RepositoryDB:IRepository
    {
        private readonly IEnumerable<IDataParser> _parsers;
        private readonly string _conectionString;

        private List<Machines>? _machines;

        public RepositoryDB(IEnumerable<IDataParser> parsers, string conectionString)
        {
            _parsers = parsers;
            _conectionString = conectionString;
        }

        public List<Machines> LoadMachines()
        {
            var client = new MongoClient(_conectionString);
            var database = client.GetDatabase("MachineAssetDB");

            var collection = database.GetCollection<BsonDocument>("Machines");

            // Synchronous fetch
            var documents = collection.Find(Builders<BsonDocument>.Filter.Empty).ToList();

            // Map BsonDocument to Machines
            var machinesList = documents.Select(doc =>
            {
                var m = new Machines
                {
                    Name = doc.GetValue("Name", "").AsString
                };

                if (doc.Contains("Assets") && doc["Assets"].IsBsonDocument)
                {
                    foreach (var asset in doc["Assets"].AsBsonDocument)
                    {
                        m.AddAsset(asset.Name, asset.Value.AsString);
                    }
                }

                return m;
            }).ToList();

            return machinesList;
        }
        public List<Machines> LoadMachines(string uploadFilePath)
        {

            if (!File.Exists(uploadFilePath))
                return new List<Machines>();

            var ext = Path.GetExtension(uploadFilePath);

            var parser = _parsers.FirstOrDefault(p => p.canHandle(ext))
                ?? throw new NotSupportedException($"No parser for {ext}");

            _machines = parser.ParseMachines(uploadFilePath);
            return _machines;
        }
    }
}

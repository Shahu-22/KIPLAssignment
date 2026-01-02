using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System.Reflection.PortableExecutable;

namespace MachineAssetManagement.Services
{
    public class DbDataLoader:IDataLoader
    {
        private readonly string _dataSource;
        private readonly IRepository _repo;
        public DbDataLoader(string dataSource,IRepository repo)
        {
            _dataSource = dataSource;
            _repo = repo;

        }

        public void SaveMatrix(string uploadedFilePath, bool replace = true)
        {
            if (string.IsNullOrWhiteSpace(uploadedFilePath))
                throw new ArgumentException("Invalid file path");

            var machines = _repo.LoadMachines(uploadedFilePath);

            var client = new MongoClient(_dataSource);
            var database = client.GetDatabase("MachineAssetDB");
            var collection = database.GetCollection<BsonDocument>("Machines");

            if(replace)
              collection.DeleteMany(Builders<BsonDocument>.Filter.Empty);

            var documents = machines.Select(m => new BsonDocument
                {
                    { "Name", m.Name },
                    { "Assets", new BsonDocument(m.Assets) }
                }).ToList();
            if (documents.Any())
            {
                collection.InsertMany(documents);
            }

        }
       
    }
}


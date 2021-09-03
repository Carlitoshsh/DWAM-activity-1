using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using sample_ms.Models;

namespace sample_ms.Services
{
    public class SupplierService
    {
        private readonly IMongoCollection<Suplier> _entity;

        public SupplierService(ISupplierDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.Database);
            _entity = database.GetCollection<Suplier>(settings.SupplierCollectionName);
        }

        public List<Suplier> Get() =>
                    _entity.Find(entity => true).ToList();

        public Suplier Get(long id) =>
            _entity.Find<Suplier>(entity => entity.Id == id).FirstOrDefault();

        public Suplier Create(Suplier entity)
        {
            _entity.InsertOne(entity);
            return entity;
        }

        public void Update(long id, Suplier entityIn) =>
            _entity.ReplaceOne(entity => entity.Id == id, entityIn);

        public void Remove(Suplier entityIn) =>
            _entity.DeleteOne(entity => entity.Id == entityIn.Id);

        public void Remove(long id) =>
            _entity.DeleteOne(entity => entity.Id == id);
    }
}
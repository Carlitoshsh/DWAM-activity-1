using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using sample_ms.Models;

namespace sample_ms.Services
{
    public class DemoService
    {
        private readonly IMongoCollection<WeatherForecast> _entity;

        public DemoService(IAccountantDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.Database);
            _entity = database.GetCollection<WeatherForecast>(settings.AccountCollectionName);
        }

        public List<WeatherForecast> Get() =>
                    _entity.Find(entity => true).ToList();

        public WeatherForecast Get(string id) =>
            _entity.Find<WeatherForecast>(entity => entity.Id == id).FirstOrDefault();

        public WeatherForecast Create(WeatherForecast entity)
        {
            _entity.InsertOne(entity);
            return entity;
        }

        public void Update(string id, WeatherForecast entityIn) =>
            _entity.ReplaceOne(entity => entity.Id == id, entityIn);

        public void Remove(WeatherForecast entityIn) =>
            _entity.DeleteOne(entity => entity.Id == entityIn.Id);

        public void Remove(string id) =>
            _entity.DeleteOne(entity => entity.Id == id);
    }
}
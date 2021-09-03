using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace sample_ms.Models
{
    public class WeatherForecast
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}

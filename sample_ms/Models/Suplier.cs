using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace sample_ms.Models
{
    public class Suplier
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int64)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string IdentificationId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}

using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.InteropServices;

namespace SovosCase.Models
{
    public class InvoiceLine
    {
        [BsonId]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string UnitCode { get; set; }
        public int UnitPrice { get; set; }
    }
}

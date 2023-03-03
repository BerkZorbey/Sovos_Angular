using MongoDB.Bson.Serialization.Attributes;

namespace SovosCase.Models
{
    public class InvoiceHeader
    {
        [BsonId]
        public string InvoiceId { get; set; }
        public string SenderTitle { get; set; }
        public string ReceiverTitle { get; set; }
        public string Date { get; set; }
    }
}

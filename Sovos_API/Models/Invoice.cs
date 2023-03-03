namespace SovosCase.Models
{
    public class Invoice
    {
        public string _id { get; set; } = Guid.NewGuid().ToString();
        public InvoiceHeader? InvoiceHeader { get; set; }
        public List<InvoiceLine>? InvoiceLine { get; set; }
    }
}

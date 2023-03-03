using MongoDB.Driver;
using SovosCase.Models;
using SovosCase.Repositories.Abstract;

namespace SovosCase.Repositories.Concrete
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IMongoCollection<Invoice> _invoice;
        public InvoiceRepository(IConfiguration configuration)
        {
            MongoClient client = new MongoClient(configuration.GetConnectionString("SovosMongoDb"));
            IMongoDatabase database = client.GetDatabase("SovosInvoiceDb");
            _invoice = database.GetCollection<Invoice>("Invoices");
        }
        public async Task<ResponseModel<Invoice>> InsertInvoice(Invoice invoice)
        {
            try
            {
                await _invoice.InsertOneAsync(invoice);
                return new ResponseModel<Invoice>(invoice);
            }
            catch(Exception ex)
            {
                return new ResponseModel<Invoice>(400,ex.Message);
            }
            
        }
    }
}

using MongoDB.Driver;
using SovosCase.Models;
using SovosCase.Repositories.Abstract;
using System.Collections.Generic;

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

        public async Task<ResponseModel<List<Invoice>>> GetAllInvoice()
        {
            try
            {
                var invoices = await _invoice.FindAsync(x => x._id != null).Result.ToListAsync();
                return new ResponseModel<List<Invoice>>(invoices);

            }
            catch(Exception ex)
            {
                return new ResponseModel<List<Invoice>>(404, ex.Message);
            }
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

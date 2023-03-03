using MongoDB.Bson;
using SovosCase.Models;
using SovosCase.Repositories.Abstract;
using SovosCase.Services.Abstract;
using System.Text.Json;

namespace SovosCase.Services.Concrete
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<ResponseModel<Invoice>> InsertInvoice(string invoice)
        {
            try
            {
                if(invoice != null)
                {
                    var newInvoice = JsonSerializer.Deserialize<Invoice>(invoice);
                    var response = await _invoiceRepository.InsertInvoice(newInvoice);
                    if(response.Success == true)
                    {
                        return new ResponseModel<Invoice>(201,response.Model);
                    }
                    else
                    {
                        throw new Exception(response.Exception.Message);
                    }
                }
                else 
                {
                    return new ResponseModel<Invoice>(400, "Invoice is null");
                }
            }
            catch(Exception ex)
            {
                return new ResponseModel<Invoice>(400, ex.Message);
            }
        }
    }
}

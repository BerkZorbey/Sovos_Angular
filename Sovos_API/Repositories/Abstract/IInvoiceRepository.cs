using Microsoft.AspNetCore.Mvc;
using SovosCase.Models;

namespace SovosCase.Repositories.Abstract
{
    public interface IInvoiceRepository
    {
        Task<ResponseModel<Invoice>> InsertInvoice(Invoice invoice);
        Task<ResponseModel<Invoice>> GetInvoiceById(string id);
        Task<ResponseModel<List<Invoice>>> GetAllInvoice();
    }
}

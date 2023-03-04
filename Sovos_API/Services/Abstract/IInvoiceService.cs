using Microsoft.AspNetCore.Mvc;
using SovosCase.Models;

namespace SovosCase.Services.Abstract
{
    public interface IInvoiceService
    {
        Task<ResponseModel<Invoice>> InsertInvoice(string invoice);
        Task<ResponseModel<Invoice>> GetInvoiceById(string id);
        Task<ResponseModel<List<Invoice>>> GetAllInvoice();
    }
}

using Microsoft.AspNetCore.Mvc;
using SovosCase.Models;

namespace SovosCase.Services.Abstract
{
    public interface IInvoiceService
    {
        Task<ResponseModel<Invoice>> InsertInvoice(string invoice);
    }
}
